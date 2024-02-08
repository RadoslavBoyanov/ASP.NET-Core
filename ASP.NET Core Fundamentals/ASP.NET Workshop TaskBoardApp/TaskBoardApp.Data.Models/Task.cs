using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using static TaskBoardApp.Common.EntityValidationConstants.Task;

namespace TaskBoardApp.Data.Models
{
	public class Task
	{
        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(TaskMaxTitle)]
		public string Title { get; set; } = string.Empty;

		[Required]
		[MaxLength(TaskMaxDescription)]
		public string Description { get; set; } = string.Empty;

		public DateTime CreatedOn { get; set; }

		[ForeignKey(nameof(Board))]
		public int? BoardId { get; set; }
		public Board? Board { get; set; } 

		[Required]
		[ForeignKey(nameof(Owner))] 
		public string OwnerId { get; set; } = null!;
		public virtual IdentityUser Owner { get; set; } = null!; 
	}
}
