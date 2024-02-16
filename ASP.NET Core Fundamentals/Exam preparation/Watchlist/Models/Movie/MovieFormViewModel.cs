using System.ComponentModel.DataAnnotations;
using static Watchlist.GlobalConstants.DataConstants.Movie;
using static Watchlist.GlobalConstants.ErrorMessages;

namespace Watchlist.Models.Movie
{
    public class MovieFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(DirectorMaxLength, MinimumLength = DirectorMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Director { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Range(typeof(decimal),"0", "10", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();

    }
}
