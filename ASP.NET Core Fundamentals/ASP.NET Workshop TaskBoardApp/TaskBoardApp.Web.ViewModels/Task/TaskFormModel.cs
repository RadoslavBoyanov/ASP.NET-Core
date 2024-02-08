using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.EntityValidationConstants.Task;

namespace TaskBoardApp.Web.ViewModels.Task
{
    using Board;
    public class TaskFormModel
    {
        public TaskFormModel()
        {
            this.AllBoards = new List<TaskBoardFormModel>();
        }

        [Required]
        [StringLength(TaskMaxTitle, MinimumLength = TaskMinTitle,
            ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskMaxDescription, MinimumLength = TaskMinDescription,
            ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int? BoardId { get; set; }

        public IEnumerable<TaskBoardFormModel> AllBoards { get; set; } = null!;
    }
}
