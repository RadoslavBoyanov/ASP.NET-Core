using Microsoft.EntityFrameworkCore;
using ShoppingList.Contracts;
using ShoppingList.Data;
using ShoppingList.Models;

namespace ShoppingList.Services
{
    public class ProductService : IProductService
    {
        private readonly ShoppingListDBContext _dbContext;

        public ProductService(ShoppingListDBContext context)
        {
            _dbContext = context;
        }

        public Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            return _dbContext.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToListAsync();
        }

        public Task AddProductAsync(ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(int id, ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
