using System.ComponentModel.DataAnnotations;
using ShoppingList.Data.Models;

namespace ShoppingList.Models
{
    public class ProductViewModel
    {
        [Required]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Product name can't be less than 3 letters!")]
        [MaxLength(30, ErrorMessage = "Product name can't be more than 30 letters!")]
        public string Name { get; set; } = string.Empty;
    }
}
