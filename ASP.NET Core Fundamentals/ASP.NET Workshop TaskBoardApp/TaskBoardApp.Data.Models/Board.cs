using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.EntityValidationConstants.Board;

namespace TaskBoardApp.Data.Models
{
    public class Board
	{
		public Board()
		{
			this.Tasks = new List<Task>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(BoardMaxName)]
		public string Name { get; set; }

        public virtual IEnumerable<Task> Tasks { get; set; } = null!;
    }
}
