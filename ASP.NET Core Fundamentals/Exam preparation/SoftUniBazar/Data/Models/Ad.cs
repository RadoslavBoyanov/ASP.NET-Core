using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUniBazar.GlobalConstants.EntityValidations.Ad;

namespace SoftUniBazar.Data.Models
{

    /// <summary>
    /// Class for ad
    /// </summary>
    public class Ad
    {
        [Key]
        [Comment("Ad id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(AdNameMaxLength)]
        [Comment("Ad name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(AdDescriptionMaxLength)]
        [Comment("Ad description")]
        public string Description { get; set; } = string.Empty;
         
        [Required]
        [Comment("Ad price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Navigation property for owner ")]
        public string OwnerId { get; set; } = null!;

        [Required, ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;

        [Required]
        [Comment("Ad image url")] public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Created date for ad")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Navigation property for category")]
        public int CategoryId { get; set; } 

        [Required, ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}
