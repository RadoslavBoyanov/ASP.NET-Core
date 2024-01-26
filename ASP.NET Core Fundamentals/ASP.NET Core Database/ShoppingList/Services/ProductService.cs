using Microsoft.EntityFrameworkCore;
using ShoppingList.Contracts;
using ShoppingList.Data;
using ShoppingList.Data.Models;
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

        public async Task AddProductAsync(ProductViewModel product)
        {
            var entity = new Product()
            {
                Name = product.Name,
            };

            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            return _dbContext.Products
                .AsNoTracking()
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToListAsync();
        }

        public async Task UpdateProductAsync(int id, ProductViewModel product)
        {
            var entity = await _dbContext.Products.FindAsync(product.Id);

            if (entity is null)
            {
                throw new ArgumentException("Invalid product!");
            }

            entity.Name = product.Name;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var entity = await _dbContext.Products.FindAsync(id);

            if (entity is null)
            {
                throw new ArgumentException("Invalid product!");
            }

            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            var entity = await _dbContext.Products.FindAsync(id);

            if (entity is null)
            {
                throw new ArgumentException("Invalid product!");
            }

            return new ProductViewModel()
            {
                Id = id,
                Name = entity.Name,
            };
        }
    }
}
