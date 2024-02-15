
using Library.Models.Category;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.GlobalConstants.DataConstants.Book;
using static Library.GlobalConstants.ErrorMessages;

namespace Library.Models.Book
{
    public class BookFormViewModel
    {
        //[Required(ErrorMessage = RequireErrorMessage)]
        
        //public int Id { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Range(RatingMinDecimal, RatingMaxDecimal)]
        [Column(TypeName = "decimal(12,3)")]
        public int Rating { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryBookViewModel> Categories { get; set; } = new List<CategoryBookViewModel>();
    }
}
