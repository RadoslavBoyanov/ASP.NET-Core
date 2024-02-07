using ShoppingList.Models;

namespace ShoppingList.Contracts
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProductsAsync();

        Task AddProductAsync(ProductViewModel product);
        Task UpdateProductAsync(int id ,ProductViewModel product);

        Task DeleteProductAsync(int id);

        Task<ProductViewModel> GetProductByIdAsync(int id);
    }
}
