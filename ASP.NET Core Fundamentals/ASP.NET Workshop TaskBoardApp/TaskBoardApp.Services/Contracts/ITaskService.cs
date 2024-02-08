using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services.Contracts
{
    public interface ITaskService
    {
        Task AddAsync(TaskFormModel viewModel, string ownerId);
        Task<TaskDetailsViewModel> GetForDetailsByIdAsync(int id);
        Task<TaskFormModel> GetTaskToEditAsync(int id, string userId);
        Task EditTaskByIdAsync(int id, TaskFormModel taskFormModel);
        Task<TaskViewModel> GetTaskToDeleteAsync(int id, string userId);
        Task DeleteTaskAsync(TaskViewModel taskViewModel, string userId);

    }
}
