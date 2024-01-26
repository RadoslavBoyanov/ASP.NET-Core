using BookManufacturingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManufacturingApp.Data
{
    public class ManufacturingBooksDbContext : DbContext
    {
        public ManufacturingBooksDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(a => a.Author);

            builder.Entity<Author>().HasData(

                new Author{Id = 1, Name = "Dan Brown", BirthDate = Convert.ToDateTime("22/06/1964"), Biography = "Dan Brown is the author of numerous #1 bestselling novels. Brown’s novels are published in 56 languages around the world with over 200 million copies in print.", Nationality = "American", Email = "danBrown@gmail.com", PhoneNumber = "0883332351", },

                new Author {Id=2, Name = "J. R. R. Tolkien", BirthDate = Convert.ToDateTime("03/01/1982"), Biography = " He has been popularly identified as the \"father\" of modern fantasy literature—or, more precisely, of high fantasy, and is widely regarded as one of the most influential authors of all time." , Nationality = "British", Email = "j.r.r.tolkien@yahoo.com", PhoneNumber = "0999283911"},

                new Author {Id = 3, Name = "George R. R. Martin", BirthDate = Convert.ToDateTime("20/09/1948"), Biography = "American novelist, screenwriter, television producer, and short story writer. He is the author of the series of epic fantasy novels A Song of Ice and Fire.", Nationality = "American", Email = "g.r.r.Martin@gmail.com", PhoneNumber = "8889106871"}
            );

            builder.Entity<Book>().HasData(

                new Book{Id = 1, AuthorId = 1, Title = "The Da Vinci Code", Genre = "Thriller", Information = "The Da Vinci Code follows symbologist Robert Langdon and cryptologist Sophie Neveu after a murder in the Louvre Museum in Paris causes them to become involved in a battle between the Priory of Sion and Opus Dei over the possibility of Jesus Christ and Mary Magdalene having had a child together.", Pages = 689, Price = 24, PrintingDate = Convert.ToDateTime("18/03/2003") },

                new Book {Id = 2, AuthorId = 2, Title = "The Hobbit", Genre = "Fantasy", Information = "The book is recognized as a classic in children's literature and is one of the best-selling books of all time, with over 100 million copies sold.", Pages = 310, Price = 18, PrintingDate = Convert.ToDateTime("21/09/1937")},

                new Book {Id = 3, AuthorId = 3, Title = "A Game of Thrones", Genre = "Fantasy", Information = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin.", Pages = 694, Price = 32, PrintingDate = Convert.ToDateTime("01/08/1996")}

            );
        }
    }
}
