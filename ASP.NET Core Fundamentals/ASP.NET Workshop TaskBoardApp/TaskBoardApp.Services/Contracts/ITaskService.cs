using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services.Contracts
{
    public interface ITaskService
    {
        Task AddAsync(string ownerId, TaskFormModel viewModel);
        Task<TaskDetailsViewModel> GetForDetailsByIdAsync(string id);
    }
}
