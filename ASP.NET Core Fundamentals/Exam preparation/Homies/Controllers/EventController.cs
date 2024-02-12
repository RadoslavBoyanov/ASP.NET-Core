using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using static Homies.GlobalConstants.EntityValidations.Event;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext _context;

        public EventController(HomiesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> All()
        {
            var events = await _context.Events
                .AsNoTracking()
                .Select(e => new EventAllInfoModels(
                    e.Id,
                    e.Name,
                    e.Start,
                    e.Type.Name,
                    e.Organiser.UserName
                )).ToListAsync();

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var e = await _context.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventParticipants)
                .FirstOrDefaultAsync();

            if (e is null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!e.EventParticipants.Any(p=> p.HelperId == userId))
            {
                e.EventParticipants.Add(new EventParticipant()
                {
                    EventId = e.Id,
                    HelperId = userId
                });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var model = await _context.EventParticipants
                .Where(ep => ep.HelperId == userId)
                .AsNoTracking()
                .Select(ep => new EventAllInfoModels(
                    ep.EventId,
                    ep.Event.Name,
                    ep.Event.Start,
                    ep.Event.Type.Name,
                    ep.Event.Organiser.UserName
                ))
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Leave(int id)
        {
            var e = await _context.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventParticipants).FirstOrDefaultAsync();

            if (e is null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var ep = e.EventParticipants.FirstOrDefault(ep => ep.HelperId == userId);

            if (ep is null)
            {
                return BadRequest();
            }

            e.EventParticipants.Remove(ep);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventFormViewModel();
            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
                    model.Start,
                    DateTimeFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out start))
            {
                ModelState
                    .AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DateTimeFormat}");
            }

            if (!DateTime.TryParseExact(
                    model.End,
                    DateTimeFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out end))
            {
                ModelState
                    .AddModelError(nameof(model.End), $"Invalid date! Format must be: {DateTimeFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();

                return View(model);
            }

            var entity = new Event()
            {
                CreatedOn = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
                OrganiserId = GetUserId(),
                TypeId = model.TypeId,
                Start = start,
                End = end
            };

            await _context.Events.AddAsync(entity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var e = await _context.Events.FindAsync(id);

            if (e is null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new EventFormViewModel()
            {
                Description = e.Description,
                Name = e.Name,
                End = e.End.ToString(DateTimeFormat),
                Start = e.Start.ToString(DateTimeFormat),
                TypeId = e.TypeId,
            };

            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormViewModel model, int id)
        {
            var e = await _context.Events
                .FindAsync(id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
                    model.Start,
                    DateTimeFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out start))
            {
                ModelState
                    .AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DateTimeFormat}");
            }

            if (!DateTime.TryParseExact(
                    model.End,
                    DateTimeFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out end))
            {
                ModelState
                    .AddModelError(nameof(model.End), $"Invalid date! Format must be: {DateTimeFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();

                return View(model);
            }

            e.Start = start;
            e.End = end;
            e.Description = model.Description;
            e.Name = model.Name;
            e.TypeId = model.TypeId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.Events
                .Where(e => e.Id == id)
                .AsNoTracking()
                .Select(e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(DateTimeFormat),
                    End = e.End.ToString(DateTimeFormat),
                    Organiser = e.Organiser.UserName,
                    CreatedOn = e.CreatedOn.ToString(DateTimeFormat),
                    Type = e.Type.Name
                })
                .FirstOrDefaultAsync();

            if (model is null)
            {
                return BadRequest();
            }

            return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<TypeViewModel>> GetTypes()
        {
            return await _context.Types
                .AsNoTracking()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }

    }
}
