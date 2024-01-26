using System.ComponentModel.DataAnnotations;

namespace BookManufacturingApp.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Name should be more than 4 letters!")]
        [MaxLength(50, ErrorMessage = "Name must be less than 50 letters!")]
        public string Name { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public string Nationality { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [StringLength(10, ErrorMessage = "Number must be from 10 numbers!")]
        public string PhoneNumber { get; set; } = string.Empty;

        [MinLength(10, ErrorMessage = "Biography must be more than 10 letters!")]
        [MaxLength(200, ErrorMessage = "Biography must be less than 200 letters!")]
        public string Biography { get; set; } = string.Empty;

        // You may include other properties or methods as needed

        public List<BookViewModel>? Books { get; set; }
    }
}
