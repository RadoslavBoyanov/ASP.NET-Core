using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
	using ForumApp.Data.Models;
	using System;

	public class ForumAppDbContext : DbContext
	{
		private Post FirstPost { get; set; }
		private Post SecondPost { get; set; }
		private Post ThirdPost { get; set; }

		public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options)
		{
			Database.Migrate();
		}

		public DbSet<Post> Posts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			SeedPost();
			modelBuilder.Entity<Post>()
				.HasData(FirstPost, SecondPost, ThirdPost);

			base.OnModelCreating(modelBuilder);
		}

		private void SeedPost()
		{
			FirstPost = new Post()
			{
				Id = 1,
				Title = "My first Post",
				Content = "My archeology education."
			};
			SecondPost = new Post()
			{
				Id = 2,
				Title = "My second post",
				Content = "My education in Software University.",
			};
			ThirdPost = new Post()
			{
				Id = 3,
				Title = "My third post",
				Content = "Books we should read."
			};
		}
	}
}
