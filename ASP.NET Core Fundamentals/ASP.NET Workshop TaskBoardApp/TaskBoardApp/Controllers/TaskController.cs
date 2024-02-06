using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Task;
using TaskBoardApp.Extensions;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IBoardService _boardService;
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService, IBoardService boardService)
        {
            _taskService = taskService;
            _boardService = boardService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel model = new TaskFormModel()
            {
                AllBoards = await this._boardService.AllForSelectAsync()
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllBoards = await this._boardService.AllForSelectAsync();
                return this.View(model);
            }

            bool boardExist = await this._boardService
                .ExistsByIdAsync(model.BoardId);
            if (!boardExist)
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected board does not exist!");
                model.AllBoards = await this._boardService.AllForSelectAsync();
                return this.View(model);
            }

            string currentUserId = this.User.GetId();

            await this._taskService.AddAsync(currentUserId, model);

            return this.RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                TaskDetailsViewModel viewModel =
                    await this._taskService.GetForDetailsByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Board");
            }
        }
    }
}
