using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SoftUniBazar.Data.Models
{
    /// <summary>
    /// Many-to-many relational mapping table between Buyer/Owner and Ad
    /// </summary>
    public class AdBuyer
    {
        [Required]
        [Comment("Navigation property for Buyer")]
        public string BuyerId { get; set; } = null!;
        [ForeignKey(nameof(BuyerId))]
        public IdentityUser Buyer { get; set; } = null!;
        [Required]
        [Comment("Navigation property for Ad")]
        public int AdId { get; set; }
        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; } = null!;
    }
}
