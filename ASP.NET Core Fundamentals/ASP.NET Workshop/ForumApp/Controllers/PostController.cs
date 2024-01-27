

using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
	using ForumApp.Contracts;
	using ForumApp.Models;
	public class PostController : Controller
	{
		private readonly IPostService _service;

		public PostController(IPostService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
		{
			var posts = await _service.GetAllAsync();
			return View(posts);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(PostFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _service.AddPostAsync(model);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			PostFormModel model = await _service.FindByIdAsync(id);
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, PostFormModel model)
		{
			await _service.EditPostAsync(id, model);
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeletePostAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
