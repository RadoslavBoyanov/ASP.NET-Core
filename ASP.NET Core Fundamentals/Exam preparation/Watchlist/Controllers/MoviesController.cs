using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models.Movie;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly WatchlistDbContext _context;

        public MoviesController(WatchlistDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allMovies = new AllMoviesQueryModel()
            {
                Movies = await _context
                    .Movies
                    .AsNoTracking()
                    .Select(m => new MovieInfoViewModel()
                    {
                        Id = m.Id,
                        ImageUrl = m.ImageUrl,
                        Title = m.Title,
                        Director = m.Director,
                        Rating = m.Rating,
                        Genre = m.Genre.Name,
                    }).ToListAsync()
            };

            return View(allMovies);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new MovieFormViewModel();
            model.Genres = GetGenres();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormViewModel model)
        {
            if (!GetGenres().Any(x=>x.Id == model.GenreId))
            {
                this.ModelState.AddModelError(nameof(model.GenreId), "Genre doesn't exist");
            }

            if (!ModelState.IsValid)
            {
                model.Genres = GetGenres();
                return View(model);
            }

            var movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId
            };

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction("All", "Movies");
        }

        public async Task<IActionResult> Watched()
        {
            string userId = GetUserId();

            var allMovies = new AllMoviesQueryModel()
            {
                Movies = await _context.UserMovies
                    .AsNoTracking()
                    .Where(um => um.UserId == userId)
                    .Select(um => new MovieInfoViewModel()
                    {
                        Id = um.Movie.Id,
                        Title = um.Movie.Title,
                        Director = um.Movie.Director,
                        ImageUrl = um.Movie.ImageUrl,
                        Rating = um.Movie.Rating,
                        Genre = um.Movie.Genre.Name
                    }).ToListAsync()
            };

            return View(allMovies);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie is null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var entry = new UserMovie()
            {
                MovieId = movie.Id,
                UserId = userId
            };

            if (await _context.UserMovies.ContainsAsync(entry))
            {
                return RedirectToAction("All", "Movies");
            }

            await _context.UserMovies.AddAsync(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction("All", "Movies");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var userId = GetUserId();
            var movie = await _context.Movies.FindAsync(id);

            if (movie is null)
            {
                return BadRequest();
            }

            var entry = await _context.UserMovies.FirstOrDefaultAsync(
                um => um.UserId == userId && um.MovieId == id);

            _context.UserMovies.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction("All", "Movies");
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private IEnumerable<GenreViewModel> GetGenres()
        {
            return _context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                });
        }
    }
}
