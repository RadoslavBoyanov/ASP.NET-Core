using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Services
{
    public class HomeService : IHomeService
    {
        private readonly TaskBoardAppDbContext _context;

        public HomeService(TaskBoardAppDbContext context)
        {
            this._context = context;
        }

        public async Task<int> GetUserTasksCountAsync(string userId)
        {
            int count = await _context.Tasks.Where(t => t.OwnerId == userId).CountAsync();
            return count;
        }

        public async Task<HomeViewModel> ConfigureHomeViewModelAsync()
        {
            List<string> boards = await _context.Boards
                .Select(b => b.Name)
                .Distinct()
                .ToListAsync();

            List<HomeBoardModel> boardTasks = new List<HomeBoardModel>();

            foreach (string board in boards)
            {
                int tasksInBoard = await _context.Tasks.Where(t => t.Board.Name == board).CountAsync();
                boardTasks.Add(new HomeBoardModel()
                {
                    BoardName = board,
                    TaskCount = tasksInBoard
                });
            }
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                AllTasksCount = await _context.Tasks.CountAsync(),
                BoardsWithTasksCount = boardTasks,
            };
            return homeViewModel;
        }
    }
}
