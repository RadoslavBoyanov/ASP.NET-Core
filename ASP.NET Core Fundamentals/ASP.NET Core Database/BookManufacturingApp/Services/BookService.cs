using BookManufacturingApp.Contracts;
using BookManufacturingApp.Data;

namespace BookManufacturingApp.Services
{
    public class BookService : IBookService
    {
        private readonly ManufacturingBooksDbContext _dbContext;

        public BookService(ManufacturingBooksDbContext context)
        {
            _dbContext = context;
        }
    }
}
