using Microsoft.EntityFrameworkCore;
using ShoppingList.Data.Models;

namespace ShoppingList.Data
{
    public class ShoppingListDBContext : DbContext
    {
        public ShoppingListDBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductNote> ProductNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductNotes)
                .WithOne(pr => pr.Product);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Cheese" },
                new Product { Id = 2, Name = "Bread" },
                new Product {Id = 3, Name = "Meat"}
            );

            modelBuilder.Entity<ProductNote>().HasData(
                new ProductNote { Id = 1, Content = "Cheese from Cow", ProductId = 1 },
                new ProductNote { Id = 2, Content = "Traditional bulgarian bread", ProductId = 2 },
                new ProductNote { Id = 3, Content = "Meat from pig", ProductId = 3 }
            );
        }
    }
}
