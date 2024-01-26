using System.ComponentModel.DataAnnotations;

namespace BookManufacturingApp.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "Name should be more than 4 letters!")]
        [MaxLength(50, ErrorMessage = "Name must be less than 50 letters!")]
        public string Title { get; set; } = string.Empty;

        [MinLength(2, ErrorMessage = "Name should be more than 4 letters!")]
        [MaxLength(20, ErrorMessage = "Name must be less than 50 letters!")]
        public string Genre { get; set; } = string.Empty;

        [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000 lv!")]
        public decimal Price { get; set; }

        [MaxLength(300, ErrorMessage = "Length should be no more than 300 letters!")]
        public string Information { get; set; } = string.Empty;

        [Range(0, 1000, ErrorMessage = "Pages must be between 0 and 10000 !")]
        public int Pages { get; set; }

        public DateTime PrintingDate { get; set; }

        public int AuthorId { get; set; }

        // You may include other properties or methods as needed

        public AuthorViewModel Author { get; set; } = null!;
    }
}
