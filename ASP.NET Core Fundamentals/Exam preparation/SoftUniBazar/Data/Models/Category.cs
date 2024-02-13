using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static SoftUniBazar.GlobalConstants.EntityValidations.Category;

namespace SoftUniBazar.Data.Models
{
    /// <summary>
    /// class for Category
    /// </summary>
    public class Category
    {
        [Key]
        [Comment("Category id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Collection of ads in this category")]
        public ICollection<Ad> Ads { get; set; } = new List<Ad>();
    }
}
