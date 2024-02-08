using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Services.Contracts
{
    public interface IHomeService
    {
        Task<int> GetUserTasksCountAsync(string userId);
        Task<HomeViewModel> ConfigureHomeViewModelAsync();
    }
}
