using BookManufacturingApp.Contracts;
using BookManufacturingApp.Data;

namespace BookManufacturingApp.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ManufacturingBooksDbContext _context;

        public AuthorService(ManufacturingBooksDbContext context)
        {
            _context = context;
        }
    }
}
