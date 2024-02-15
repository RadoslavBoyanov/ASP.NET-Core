using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Library.GlobalConstants.DataConstants.Category;

namespace Library.Data.Models
{
    /// <summary>
    /// Class for category book
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

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
