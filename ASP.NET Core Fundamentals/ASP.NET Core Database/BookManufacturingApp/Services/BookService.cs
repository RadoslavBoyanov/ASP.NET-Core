using BookManufacturingApp.Contracts;
using BookManufacturingApp.Data;
using BookManufacturingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManufacturingApp.Services
{
    public class BookService : IBookService
    {
        private readonly ManufacturingBooksDbContext _dbContext;

        public BookService(ManufacturingBooksDbContext context)
        {
            _dbContext = context;
        }

        public Task<List<BookViewModel>> GetAllBooksAsync()
        {
            return _dbContext.Books
                .AsNoTracking()
                .Select(book => new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Genre = book.Genre,
                    Information = book.Information,
                    Price = book.Price,
                    Pages = book.Pages,
                    PrintingDate = book.PrintingDate,
                    Author = new AuthorViewModel
                    {
                        Id = book.Author.Id,
                        Name = book.Author.Name,
                        BirthDate = book.Author.BirthDate,
                        Nationality = book.Author.Nationality,
                        Email = book.Author.Email,
                        PhoneNumber = book.Author.PhoneNumber,
                        Biography = book.Author.Biography
                    }
                }).ToListAsync();
        }

        public Task AddBookAsync(BookViewModel bookViewModel)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBookAsync(int id, BookViewModel bookViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookViewModel> GetBookByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
