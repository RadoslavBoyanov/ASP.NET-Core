using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
	{
		private readonly IHomeService _homeService;

		public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

		public async Task<IActionResult> Index()
		{
            int userTaskCount = 0;
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                userTaskCount = await _homeService.GetUserTasksCountAsync(GetUserId());
            }
            HomeViewModel homeViewModel = await _homeService.ConfigureHomeViewModelAsync();
            homeViewModel.UserTasksCount = userTaskCount;

            return View(homeViewModel);
        }
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
