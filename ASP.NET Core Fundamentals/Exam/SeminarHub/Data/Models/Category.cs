using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.GlobalConstants.DataConstants.Category;

namespace SeminarHub.Data.Models
{
    /// <summary>
    /// Class for different categories in seminars 
    /// </summary>
    public class Category
    {
        [Key]
        [Comment("Category id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Collection of seminars")]
        public IEnumerable<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}
