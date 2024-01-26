using BookManufacturingApp.Contracts;
using BookManufacturingApp.Data;
using BookManufacturingApp.Models;

namespace BookManufacturingApp.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ManufacturingBooksDbContext _context;

        public AuthorService(ManufacturingBooksDbContext context)
        {
            _context = context;
        }

        public Task<List<AuthorViewModel>> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddProductAsync(AuthorViewModel author)
        {
            throw new NotImplementedException();
        }

        public Task UpdaterProductAsync(int id, AuthorViewModel author)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorViewModel> GetAuthorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookViewModel>> GetAllBooksFromOneAuthorAsync(int id, BookViewModel books)
        {
            throw new NotImplementedException();
        }
    }
}
