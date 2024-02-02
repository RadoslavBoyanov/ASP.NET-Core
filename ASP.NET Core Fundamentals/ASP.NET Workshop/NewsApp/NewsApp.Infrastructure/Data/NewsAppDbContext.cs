namespace NewsApp.Infrastructure.Data
{
	using Microsoft.EntityFrameworkCore;

	using Models;

	public class NewsAppDbContext : DbContext
	{
		public NewsAppDbContext(DbContextOptions<NewsAppDbContext> options) : base(options)
		{
			
		}

		public DbSet<Journalist> Journalists { get; set; }
		
		public DbSet<Article> Articles { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<CategoryJournalist> CategoriesJournalists{ get; set;}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<CategoryJournalist>().HasKey(key => new
			{
				key.CategoryId, key.JournalistId
			});

			modelBuilder.Entity<CategoryJournalist>()
				.HasOne(c => c.Category)
				.WithMany(cj => cj.CategoryJournalists)
				.HasForeignKey(fk => fk.CategoryId);

			modelBuilder.Entity<CategoryJournalist>().HasOne(j => j.Journalist)
				.WithMany(cj => cj.CategoryJournalists)
				.HasForeignKey(fk => fk.JournalistId);

			modelBuilder.Entity<Article>()
				.HasOne(a => a.Category)
				.WithMany(nc => nc.Articles)
				.HasForeignKey(a => a.CategoryId)
				.OnDelete(DeleteBehavior.Restrict); 

			modelBuilder.Entity<Article>()
				.HasOne(a => a.Journalist)
				.WithMany(j => j.Articles)
				.HasForeignKey(a => a.JournalistId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Journalist>()
				.HasMany(j => j.CategoryJournalists)
				.WithOne(ncj => ncj.Journalist)
				.HasForeignKey(ncj => ncj.JournalistId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
