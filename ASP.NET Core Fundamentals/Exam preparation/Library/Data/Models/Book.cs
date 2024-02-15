using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.GlobalConstants.DataConstants.Book;

namespace Library.Data.Models
{
    /// <summary>
    /// Class for book
    /// </summary>
    public class Book
    {
        [Key]
        [Comment("Book id")]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        [Comment("Book title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(AuthorMaxLength)]
        [Comment("Book author")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength)]
        [Comment("Book description")]
        public string Description { get; set; } = string.Empty;

        [Required] [Comment("Book cover")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Range(RatingMinDecimal, RatingMaxDecimal)]
        [Comment("Book rating")]
        public decimal Rating { get; set; }

        [Required]
        [Comment("Navigation property for category")]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public ICollection<ApplicationUserBook> ApplicationUserBooks { get; set; } = new List<ApplicationUserBook>();
    }
}
