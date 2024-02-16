using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Watchlist.GlobalConstants.DataConstants.Genre;

namespace Watchlist.Data.Models
{
    public class Genre
    {
        [Key]
        [Comment("Genre id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Genre name")] 
        public string Name { get; set; } = string.Empty;

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
