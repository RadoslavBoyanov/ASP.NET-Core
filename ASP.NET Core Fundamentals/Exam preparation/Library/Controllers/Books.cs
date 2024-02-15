using Library.Data;
using Library.Data.Models;
using Library.Models.Book;
using Library.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class Books : Controller
	{
		private readonly LibraryDbContext _context;

		public Books(LibraryDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> All()
		{
			var allBooks = new AllBooksQueryModel()
			{
				Books = await _context.Books
					.AsNoTracking()
					.Select(b => new BookInfoViewModel()
					{
                        Id = b.Id,
						ImageUrl = b.ImageUrl,
						Title = b.Title,
						Author = b.Author,
						Rating = b.Rating.ToString(),
						Category = b.Category.Name
					}).ToListAsync()
			};
			return View(allBooks);
		}

        public async Task<IActionResult> Mine(int id)
        {
            var userId = GetUserId();
			var currentUser = await _context.Users.FindAsync(userId);

            var allBooks = new AllBooksQueryModel()
            {
                Books = await _context.ApplicationUsersBooks
                    .AsNoTracking()
                    .Where(ub => ub.ApplicationUserId == userId)
                    .Select(ub => new BookInfoViewModel()
                    {
                        Id = ub.Book.Id,
                        Title = ub.Book.Title,
                        Author = ub.Book.Author,
                        Rating = ub.Book.Rating.ToString(),
                        Category = ub.Book.Category.Name,
                        Description = ub.Book.Description,
                    }).ToListAsync()
            };
            return View(allBooks);
        }

        public IActionResult Add()
        {
            var model = new BookFormViewModel();
            model.Categories =GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormViewModel model)
        {
            if (!GetCategories().Any(c=> c.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = GetCategories();
                return View(model);
            }

            var newBook = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return RedirectToAction("All", "Books");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            var entry = new ApplicationUserBook()
            {
                ApplicationUserId = userId,
                BookId = book.Id
            };

            if (await _context.ApplicationUsersBooks.ContainsAsync(entry))
            {
                return RedirectToAction("All", "Books");
            }

            await _context.ApplicationUsersBooks.AddAsync(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction("All", "Books");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var bookId = id;
            var book = await _context.Books.FindAsync(id);
            if (book is null)
            {
                return BadRequest();
            }

            var userId = GetUserId();
            var entry = await _context.ApplicationUsersBooks.FirstOrDefaultAsync(ub =>
                ub.ApplicationUserId == userId && ub.BookId == id);

            _context.ApplicationUsersBooks.Remove(entry);
            await _context.SaveChangesAsync();

            return RedirectToAction("Mine", "Books");

        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private IEnumerable<CategoryBookViewModel> GetCategories()
        {
			return _context.Categories
				.AsNoTracking()
                .Select(c => new CategoryBookViewModel()
                {
					Id = c.Id,
					Name = c.Name,
                });
        }
    }
}
