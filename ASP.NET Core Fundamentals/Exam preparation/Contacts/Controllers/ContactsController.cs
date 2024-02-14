using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Models.Contact;
using Contacts.Models.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly ContactsDbContext _context;

        public ContactsController(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> All()
        {
            var allContacts = new AllContactsQueryModel()
            {
                Contacts = _context.Contacts
                    .AsNoTracking()
                    .Select(c => new ContactInfoViewModel()
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber,
                        Address = c.Address,
                        Website = c.Website
                    })
            };

            return View(allContacts);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ContactFormViewModel model = new ContactFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Contact viewModel = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Website = model.Website
            };

            await _context.Contacts.AddAsync(viewModel);
            await _context.SaveChangesAsync();

            return RedirectToAction("All", "Contacts");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var contactForEdit = await _context.Contacts.FindAsync(id);

            if (contactForEdit is null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            ContactFormViewModel contactModel = new ContactFormViewModel()
            {
                FirstName = contactForEdit.FirstName,
                LastName = contactForEdit.LastName,
                Email = contactForEdit.Email,
                PhoneNumber = contactForEdit.PhoneNumber,
                Website = contactForEdit.Website,
                Address = contactForEdit.Address
            };

            return View(contactModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ContactFormViewModel contact)
        {
            var contactForEdit = await _context.Contacts.FindAsync(id);
            if (contactForEdit is null)
            {
                return BadRequest();
            }

            contactForEdit.FirstName = contact.FirstName;
            contactForEdit.LastName = contact.LastName;
            contactForEdit.Email = contact.Email;
            contactForEdit.PhoneNumber = contact.PhoneNumber;
            contactForEdit.Website = contact.Website;
            contactForEdit.Address = contact.Address;

            await _context.SaveChangesAsync();
            return RedirectToAction("All", "Contacts");
        }

        public async Task<IActionResult> Team()
        {
            string userId = GetUserId();
            var currentUser = await _context.Users.FindAsync(userId);

            var allContacts = new AllContactsQueryModel()
            {
                Contacts = await _context.ApplicationUserContacts
                    .Where(ap => ap.ApplicationUserId == currentUser.Id)
                    .Select(ap => new ContactInfoViewModel()
                    {
                        Id = ap.Contact.Id,
                        FirstName = ap.Contact.FirstName,
                        LastName = ap.Contact.LastName,
                        Email = ap.Contact.Email,
                        PhoneNumber = ap.Contact.PhoneNumber,
                        Address = ap.Contact.Address,
                        Website = ap.Contact.Website
                    }).ToListAsync()
            };

            return View(allContacts);
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact is null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            var entry = new ApplicationUserContact()
            {
                ContactId = contact.Id,
                ApplicationUserId = userId
            };

            if (await _context.ApplicationUserContacts.ContainsAsync(entry))
            {
                return RedirectToAction("All", "Contacts");
            }

            await _context.ApplicationUserContacts.AddAsync(entry);
            await _context.SaveChangesAsync();

            return RedirectToAction("All", "Contacts");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int id)
        {
            var user = GetUserId();
            var contact = await _context.Contacts.FindAsync(id);

            if (contact is null)
            {
                return BadRequest();
            }

            var entry = await _context.ApplicationUserContacts
                .FirstOrDefaultAsync(ap => ap.ApplicationUserId == user && ap.ContactId == id);

            _context.ApplicationUserContacts.Remove(entry);
            await _context.SaveChangesAsync();

            return RedirectToAction("Team", "Contacts");
        }

        private string GetUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
