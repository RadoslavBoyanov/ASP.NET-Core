using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Task;
using TaskBoardApp.Extensions;
using System.Security.Claims;
using TaskBoardApp.Services;

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
            TaskFormModel taskFormModel = new TaskFormModel()
            {
                AllBoards = await this._boardService.GetExistingBoards()
            };

            return View(taskFormModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskFormModel)
        {
            IEnumerable<TaskBoardFormModel> existingBoards = await _boardService.GetExistingBoards();
            if (!existingBoards.Any(b => b.Id == taskFormModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskFormModel.BoardId), "Board does not exist");
            }
            string currentUserId = GetUserId();
            if (!ModelState.IsValid)
            {
                taskFormModel.AllBoards = existingBoards;
                return View(taskFormModel);
            }
            await _taskService.AddAsync(taskFormModel, currentUserId);

            return RedirectToAction("All", "Board");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                TaskDetailsViewModel model = await _taskService.GetForDetailsByIdAsync(id);
                return View(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                TaskFormModel taskFormModel = await _taskService.GetTaskToEditAsync(id, GetUserId());
                return View(taskFormModel);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskFormModel)
        {
            await _taskService.EditTaskByIdAsync(id, taskFormModel);
            return RedirectToAction("All", "Board");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                TaskViewModel taskViewModel = await _taskService.GetTaskToDeleteAsync(id, GetUserId());
                return View(taskViewModel);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskViewModel)
        {
            try
            {
                await _taskService.DeleteTaskAsync(taskViewModel, GetUserId());
                return RedirectToAction("All", "Board");
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }
        }
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
