
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data.Data.Configurations
{
	public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
	{
		public void Configure(EntityTypeBuilder<Task> builder)
		{
			builder
				.HasOne(t => t.Board)
				.WithMany(b => b.Tasks)
				.HasForeignKey(t => t.BoardId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasData(this.GenerateTasks());
		}

		private ICollection<Task> GenerateTasks()
		{
			ICollection<Task> tasks = new HashSet<Task>()
			{
				new Task()
				{
					Id = 1,
					Title = "Improve CSS styles",
					Description = "Implement better styling for all public pages",
					CreatedOn = DateTime.UtcNow.AddDays(-200),
					OwnerId = "c544d269-4891-459b-b841-dcdc6f11f755",
					BoardId = 1
				},
				new Task()
				{
					Id = 2,
					Title = "Android Client App",
					Description = "Create Android client App for the RESTful TaskBoard service",
					CreatedOn = DateTime.UtcNow.AddMonths(-5),
					OwnerId = "af2558e7-083d-487b-8583-42fe65ce8360",
					BoardId = 1
				},
				new Task()
				{
					Id = 3,
					Title = "Desktop Client App",
					Description = "Create Desktop client App for the RESTful TaskBoard service",
					CreatedOn = DateTime.UtcNow.AddMonths(-1),
					OwnerId = "c544d269-4891-459b-b841-dcdc6f11f755",
					BoardId = 2
				},
				new Task()
				{
					Id = 4,
					Title = "Create Tasks",
					Description = "Implement [Create Task] page for adding tasks",
					CreatedOn = DateTime.UtcNow.AddYears(-1),
					OwnerId = "c544d269-4891-459b-b841-dcdc6f11f755",
					BoardId = 3
				}
			};

			return tasks;
		}
	}
}
