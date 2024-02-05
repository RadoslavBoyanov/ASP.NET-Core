using CatLovers.Infrastructure.Data.Configurations;
using CatLovers.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CatLovers.Infrastructure.Data
{
	public class FelidaeDbContext : DbContext
	{
		public FelidaeDbContext(DbContextOptions<FelidaeDbContext> options) : base(options)
		{
			
		}

		public DbSet<Family>? Families { get; set; }
		public DbSet<SubFamily>? SubFamilies { get; set; }
		public DbSet<Genus>? Genera { get; set; }
		public DbSet<Species>? Species { get; set; }
		public DbSet<SubSpecies>? SubSpecies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new FamilyEntityConfiguration());
			modelBuilder.ApplyConfiguration(new SubFamilyConfiguration());
			modelBuilder.ApplyConfiguration(new GenusConfiguration());
			modelBuilder.ApplyConfiguration(new SpeciesConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}
