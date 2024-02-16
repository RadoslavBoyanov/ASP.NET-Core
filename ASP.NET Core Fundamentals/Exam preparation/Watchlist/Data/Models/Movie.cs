using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.GlobalConstants.DataConstants.Movie;

namespace Watchlist.Data.Models
{
    public class Movie
    {
        [Key]
        [Comment("Movie id")]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        [Comment("Movie title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DirectorMaxLength)]
        [Comment("Movie director")]
        public string Director { get; set; } = string.Empty;

        [Required] 
        [Column(name: "Image URL")] 
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        [Comment("Navigation property for Genre")]
        public int GenreId { get; set; }

        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public ICollection<UserMovie> UserMovies { get; set; } = new HashSet<UserMovie>();
    }
}
