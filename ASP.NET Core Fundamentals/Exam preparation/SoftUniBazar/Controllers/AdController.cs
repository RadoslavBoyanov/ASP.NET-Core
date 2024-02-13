using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models.Ad;
using SoftUniBazar.Models.Category;
using System.Security.Claims;
using static SoftUniBazar.GlobalConstants.EntityValidations.Ad;


namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext _dbContext;

        public AdController(BazarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Add()
        {
            AdFormModelView model = new AdFormModelView()
            {
                Categories = GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormModelView model)
        {
            if (!GetCategories().Any(e => e.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = GetUserId();

            var adToAdd = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                CategoryId = model.CategoryId,
                Price = model.Price,
                OwnerId = userId,
                ImageUrl = model.ImageUrl
            };

            await _dbContext.AddAsync(adToAdd);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }

        public async Task<IActionResult> All()
        {
            var ads = await _dbContext.Ads
                .AsNoTracking()
                .Select(a => new AdAllViewModel()
                    {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    CreatedOn = a.CreatedOn.ToString(DateTimeFormat),
                    Category = a.Category.Name,
                    Price = a.Price,
                    Owner = a.Owner.UserName,
                    ImageUrl = a.ImageUrl
                    })
                .ToListAsync();

            return View(ads);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ad = await _dbContext.Ads
                .FindAsync(id);

            if (ad is null)
            {
                return BadRequest();
            }

            if (ad.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new AdFormModelView()
            {
                Name = ad.Name,
                Description = ad.Description,
                Price = ad.Price,
                CategoryId = ad.CategoryId,
                Categories = GetCategories(),
                ImageUrl = ad.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdFormModelView model)
        {
            var adToEdit =  await _dbContext.Ads
                .FindAsync(id);

            if (adToEdit is null)
            {
                return BadRequest();
            }

            if (adToEdit.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            if (!GetCategories().Any(c=>c.Id == adToEdit.CategoryId))
            {
                ModelState.AddModelError(nameof(adToEdit.CategoryId), "Category does not exist!");
            }

            adToEdit.Name = model.Name;
            adToEdit.Description = model.Description;
            adToEdit.Price = model.Price;
            adToEdit.ImageUrl = model.ImageUrl;
            adToEdit.CategoryId = model.CategoryId;

            await _dbContext.SaveChangesAsync();
            return RedirectToAction("All", "Ad");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var userId = GetUserId();

            var userAds = await _dbContext
                .AdsBuyers
                .AsNoTracking()
                .Where(ab => ab.BuyerId == userId)
                .Select(ab => new AdAllViewModel()
                {
                    Id = ab.Ad.Id,
                    Name = ab.Ad.Name,
                    Description = ab.Ad.Description,
                    CreatedOn = ab.Ad.CreatedOn.ToString(DateTimeFormat),
                    Category = ab.Ad.Category.Name,
                    Price = ab.Ad.Price,
                    ImageUrl = ab.Ad.ImageUrl,
                    Owner = ab.Ad.Owner.ToString()
                })
                .ToListAsync();

            return View(userAds);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var adToAdd = await _dbContext.Ads.FindAsync(id);

            if (adToAdd == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            var newEntry = new AdBuyer()
            {
                AdId = adToAdd.Id,
                BuyerId = userId
            };

            if (await _dbContext.AdsBuyers.ContainsAsync(newEntry))
            {
                return RedirectToAction("Cart", "Ad");
            }

            await _dbContext.AdsBuyers.AddAsync(newEntry);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Cart", "Ad");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var adId = id;
            var userId = GetUserId();

            var adToRemove = await _dbContext.Ads.FindAsync(adId);
            if (adToRemove == null)
            {
                return BadRequest();
            }

            var entry = await _dbContext.AdsBuyers
                .FirstOrDefaultAsync(ab => ab.BuyerId == userId && ab.AdId == adId);
            _dbContext.AdsBuyers.Remove(entry);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }


        private IEnumerable<CategoryFormModelView> GetCategories()
        {
            return _dbContext.Categories
                .Select(c => new CategoryFormModelView()
                {
                    Id = c.Id,
                    Name = c.Name,
                });
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
