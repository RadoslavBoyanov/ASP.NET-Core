using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManufacturingApp.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Genre { get; set; } = string.Empty;

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(300)]
        public string Information { get; set; } = string.Empty;

        [Required]
        [Range(20, 10_000)]
        public int Pages { get; set; }

        [Required]
        public DateTime PrintingDate { get; set; }

        [Required] 
        public int AuthorId { get; set; }

        [Required]
        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; } = null!;
    }
}
