using BookManufacturingApp.Contracts;
using BookManufacturingApp.Data;
using BookManufacturingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManufacturingApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService service;

        public BookController(IBookService bookService)
        {
            service = bookService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<BookViewModel> allBooks = await this.service.GetAllBooksAsync();
            return View(allBooks);
        }
    }
}
