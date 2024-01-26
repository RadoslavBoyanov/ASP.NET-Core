using System.ComponentModel.DataAnnotations;

namespace BookManufacturingApp.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Name { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public string Nationality { get; set; } = string.Empty;

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; } = string.Empty;

        [RegularExpression("^[0-9]{10}$")] 
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(200, MinimumLength = 10)]
        public string Biography { get; set; } = string.Empty;

        public ICollection<Book>? Books { get; set; }
    }
}
