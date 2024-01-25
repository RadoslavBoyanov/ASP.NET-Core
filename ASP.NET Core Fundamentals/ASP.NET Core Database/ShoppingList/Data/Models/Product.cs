using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30), MinLength(3)]
        public string Name { get; set; } = string.Empty;

        public IList<ProductNote> ProductNotes { get; set; }
            = new List<ProductNote>();
    }
}
