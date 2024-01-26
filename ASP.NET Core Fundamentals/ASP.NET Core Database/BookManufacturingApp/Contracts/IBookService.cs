using BookManufacturingApp.Models;

namespace BookManufacturingApp.Contracts
{
    public interface IBookService
    {
        Task<List<BookViewModel>> GetAllBooksAsync();

        Task AddBookAsync(BookViewModel bookViewModel);

        Task RemoveBookAsync(int id,BookViewModel bookViewModel);

        Task DeleteBookAsync(int id);

        Task<BookViewModel> GetBookByIdAsync(int id);
    }
}
