using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models.Category;
using SeminarHub.Models.Seminar;
using System.Globalization;
using System.Security.Claims;
using static SeminarHub.GlobalConstants.DataConstants.Seminar;
using static SeminarHub.GlobalConstants.ErrorMessages;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext _context;

        public SeminarController(SeminarHubDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> All()
        {
            var seminars = await _context.Seminars
                .AsNoTracking()
                .Select(s => new SeminarAllViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Organizer.UserName,
                    s.Category.Name,
                    s.DateAndTime
                )).ToListAsync();

            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var userId = GetUserId();

            var model = await _context.SeminarsParticipants
                .Where(sp => sp.ParticipantId == userId)
                .AsNoTracking()
                .Select(sp => new SeminarAllViewModel(
                    sp.Seminar.Id,
                    sp.Seminar.Topic,
                    sp.Seminar.Lecturer,
                    sp.Seminar.Organizer.UserName,
                    sp.Seminar.Category.Name,
                    sp.Seminar.DateAndTime
                )).ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var seminar = await _context.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar is null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            if (!seminar.SeminarsParticipants.Any(p=> p.ParticipantId == userId))
            {
                seminar.SeminarsParticipants.Add(new SeminarParticipant()
                {
                    SeminarId = seminar.Id,
                    ParticipantId = userId
                });

                await _context.SaveChangesAsync();

                return RedirectToAction("Joined", "Seminar");
            }

            return RedirectToAction("All", "Seminar");
            
        }

        public async Task<IActionResult> Leave(int id)
        {
            var seminar = await _context.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar is null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            var seminarStudent = seminar.SeminarsParticipants.FirstOrDefault(sp => sp.ParticipantId == userId);

            if (seminarStudent is null)
            {
                return BadRequest();
            }

            seminar.SeminarsParticipants.Remove(seminarStudent);

            await _context.SaveChangesAsync();

            return RedirectToAction("Joined", "Seminar");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormViewModel();
            model.Categories = await GetCategories();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormViewModel model)
        {
            DateTime date = DateTime.Now;

            if (!DateTime.TryParseExact(model.DateAndTime, DateAndTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), DateErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            var entity = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                DateAndTime = date,
                OrganizerId = GetUserId(),
                Duration = model.Duration,
                CategoryId = model.CategoryId
            };

            await _context.Seminars.AddAsync(entity);
            await _context.SaveChangesAsync();

            return RedirectToAction("All", "Seminar");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var seminar = await _context.Seminars.FindAsync(id);

            if (seminar is null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new SeminarFormViewModel()
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Details,
                DateAndTime = seminar.DateAndTime.ToString(DateAndTimeFormat),
                Duration = seminar.Duration,
                CategoryId = seminar.CategoryId
            };

            model.Categories = await GetCategories();

            return View(model);
        }

        public async Task<IActionResult> Edit(SeminarFormViewModel model, int id)
        {
            var seminar = await _context.Seminars.FindAsync(id);

            if (seminar is null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime date = DateTime.Now;

            if (!DateTime.TryParseExact(model.DateAndTime, DateAndTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), DateErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            seminar.Topic = model.Topic;
            seminar.Lecturer = model.Lecturer;
            seminar.Details = model.Details;
            seminar.DateAndTime = date;
            seminar.Duration = model.Duration;
            seminar.CategoryId = model.CategoryId;

            await _context.SaveChangesAsync();
            return RedirectToAction("All", "Seminar");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.Seminars
                .Where(s => s.Id == id)
                .AsNoTracking()
                .Select(s => new SeminarDetailsViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    DateAndTime = s.DateAndTime.ToString(DateAndTimeFormat),
                    Organizer = s.Organizer.UserName,
                    Category = s.Category.Name,
                    Duration = Convert.ToInt32(s.Duration.ToString()),
                    Details = s.Details,
                    Lecturer = s.Lecturer
                }).FirstOrDefaultAsync();

            if (model is null)
            {
                return BadRequest();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var seminar = await _context.Seminars.Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants).FirstOrDefaultAsync();

            if (seminar is null)
            {
                return BadRequest();
            }

            var model = new SeminarDeleteViewModel()
            {
                Id = seminar.Id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seminar = await _context.Seminars.FindAsync(id);

            if (seminar is null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var seminarStudents = _context.SeminarsParticipants
                .Where(sp => sp.SeminarId == id).ToList();

            if (seminarStudents.Any())
            {
                foreach (var student in seminarStudents)
                {
                    _context.SeminarsParticipants.Remove(student);
                }

                await _context.SaveChangesAsync();
            }

            _context.Seminars.Remove(seminar);

            await _context.SaveChangesAsync();

            return RedirectToAction("All", "Seminar");
        }


        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await _context.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
        }
    }
}
