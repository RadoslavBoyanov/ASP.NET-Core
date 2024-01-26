using BookManufacturingApp.Models;

namespace BookManufacturingApp.Contracts
{
    public interface IAuthorService
    {
        Task<List<AuthorViewModel>> GetAllAuthorsAsync();

        Task AddProductAsync(AuthorViewModel author);

        Task UpdaterProductAsync(int id,AuthorViewModel author);

        Task DeleteProductAsync(int id);

        Task<AuthorViewModel> GetAuthorByIdAsync(int id);

        Task<List<BookViewModel>> GetAllBooksFromOneAuthorAsync(int id, BookViewModel books);
    }
}
