using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services
{
    public class BoardService : IBoardService
	{
		private readonly TaskBoardAppDbContext _context;

		public BoardService(TaskBoardAppDbContext context)
		{
			this._context = context;
		}

		public async Task<IEnumerable<BoardAllViewModel>> AllAsync()
		{
            List<BoardAllViewModel> boards = await _context
                .Boards.Select(b => new BoardAllViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.NormalizedUserName
                    })
                }).ToListAsync();
            return boards;
        }

        public async Task<IEnumerable<TaskBoardFormModel>> GetExistingBoards()
        {
            IEnumerable<TaskBoardFormModel> existingBoards = await _context
                .Boards.Select(b => new TaskBoardFormModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                }).ToListAsync();

            return existingBoards;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this._context
                .Boards
                .AnyAsync(b => b.Id == id);

            return result;
        }
    }
}
