using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Web.ViewModels.Board
{
	public class BoardAllViewModel
	{
        public BoardAllViewModel()
        {
            Tasks = new List<TaskViewModel>();
        }
        public int Id { get; init; }

        public string Name { get; set; } = null!;
        public IEnumerable<TaskViewModel> Tasks { get; set; } = null!;
    }
}
