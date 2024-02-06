using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using static TaskBoardApp.Common.EntityValidationConstants.Task;

namespace TaskBoardApp.Data.Models
{
	public class Task
	{
		public Task()
		{
			this.Id = Guid.NewGuid();
		}

		[Key]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(TaskMaxTitle)]
		public string Title { get; set; } = string.Empty;

		[Required]
		[MaxLength(TaskMaxDescription)]
		public string Description { get; set; } = string.Empty;

		public DateTime CreatedOn { get; set; }

		public int BoardId { get; set; }
		public virtual Board Board { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Owner))] 
		public string OwnerId { get; set; } = string.Empty;
		public virtual IdentityUser Owner { get; set; } = null!; 
	}
}
