using Microsoft.AspNetCore.Mvc;
using ShoppingList.Contracts;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<ProductViewModel> allproducts = await this.productService.GetAllProductsAsync();

            return View(allproducts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.productService.AddProductAsync(newProduct);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var productViewModel = await this.productService.GetProductByIdAsync(id);
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductViewModel product)
        {
            if (!ModelState.IsValid || product.Id != id)
            {
                return View();
            }

            await productService.UpdateProductAsync(id, product);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
