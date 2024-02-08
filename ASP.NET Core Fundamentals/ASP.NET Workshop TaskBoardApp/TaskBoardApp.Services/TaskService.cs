using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskBoardAppDbContext _db;

        public TaskService(TaskBoardAppDbContext dbContext)
        {
            _db = dbContext;
        }

        public async System.Threading.Tasks.Task AddAsync(TaskFormModel viewModel, string ownerId)
        {
            Data.Models.Task task = new Data.Models.Task()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = viewModel.BoardId,
                OwnerId = ownerId
            };


            await this._db.Tasks.AddAsync(task);
            await _db.SaveChangesAsync();
        }

        public async Task<TaskDetailsViewModel> GetForDetailsByIdAsync(int id)
        {
            TaskDetailsViewModel taskDetailsViewModel = await _db.Tasks
                .Where(t => t.Id == id).Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                }).FirstOrDefaultAsync();
            if (taskDetailsViewModel == null)
            {
                throw new ArgumentException("Invalid task id");
            }
            return taskDetailsViewModel;
        }

        public async System.Threading.Tasks.Task EditTaskByIdAsync(int id, TaskFormModel taskFormModel)
        {
            Task task = await GetTaskByIdAsync(id);
            task.Title = taskFormModel.Title;
            task.Description = taskFormModel.Description;
            task.BoardId = taskFormModel.BoardId;
            await _db.SaveChangesAsync();
        }


        public async Task<TaskFormModel> GetTaskToEditAsync(int id, string userId)
        {
            Task taskToGet = await GetTaskByIdAsync(id);
            if (taskToGet.OwnerId != userId)
            {
                throw new InvalidOperationException("User unauthorized");
            }
            TaskFormModel taskFormModel = new TaskFormModel()
            {
                Title = taskToGet.Title,
                Description = taskToGet.Title,
                BoardId = taskToGet.BoardId,
                AllBoards = _db.Boards.Select(b => new TaskBoardFormModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
            };
            return taskFormModel;
        }

        public async Task<TaskViewModel> GetTaskToDeleteAsync(int id, string userId)
        {
            Task task = await GetTaskByIdAsync(id);
            if (!CheckUserId(task.OwnerId, userId))
            {
                throw new InvalidOperationException("User unauthorized");
            }
            TaskViewModel taskViewModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };
            return taskViewModel;
        }


        public async System.Threading.Tasks.Task DeleteTaskAsync(TaskViewModel taskViewModel, string userId)
        {
            Task task = await GetTaskByIdAsync(taskViewModel.Id);
            if (!CheckUserId(task.OwnerId, userId))
            {
                throw new InvalidOperationException("User unauthorized");
            }
            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
        }

        private async Task<Task> GetTaskByIdAsync(int id)
        {
            Task task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                throw new ArgumentException("Invalid task id");
            }
            return task;
        }

        private bool CheckUserId(string ownerId, string userId) => ownerId == userId;

    }
}
