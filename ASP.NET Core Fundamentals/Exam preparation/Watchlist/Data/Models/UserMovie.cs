using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Watchlist.Data.Models
{
    /// <summary>
    /// Many-to-many relation between User and Movie
    /// </summary>
    public class UserMovie
    {
        [Required]
        [Comment("Navigation property for User")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))] 
        public User User { get; set; } = null!;

        [Required]
        [Comment("Navigation property for movie")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))] 
        public Movie Movie { get; set; } = null!;
    }
}
