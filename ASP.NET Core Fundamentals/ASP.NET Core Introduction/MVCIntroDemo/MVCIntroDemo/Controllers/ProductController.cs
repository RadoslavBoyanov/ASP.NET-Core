using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Models.Product;

namespace MVCIntroDemo.Controllers
{
	public class ProductController : Controller
	{
		private readonly ILogger  _logger;

		private IEnumerable<ProductViewModel> _products
			= new List<ProductViewModel>()
			{
				new ProductViewModel()
				{
					Id = 1,
					Name = "Cheese",
					Price = 7.00
				},
				new ProductViewModel()
				{
					Id = 2,
					Name = "Ham",
					Price = 5.50
				},
				new ProductViewModel()
				{
					Id = 3,
					Name = "Bread",
					Price = 2.20
				},
			};

		public ProductController(ILogger<ProductController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View(_products);
		}

		public IActionResult ById(int id)
		{
			var product = _products.FirstOrDefault(p => p.Id == id);

			if (product == null)
			{
				return BadRequest();
			}

			return View(product);
		}
	}
}
