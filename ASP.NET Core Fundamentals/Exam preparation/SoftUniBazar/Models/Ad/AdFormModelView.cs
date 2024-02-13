using SoftUniBazar.Models.Category;
using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.GlobalConstants.EntityValidations.Ad;
using static SoftUniBazar.GlobalConstants.ErrorMessages;

namespace SoftUniBazar.Models.Ad
{
    public class AdFormModelView
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(AdNameMaxLength, MinimumLength = AdNameMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(AdDescriptionMaxLength, MinimumLength = AdDescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public IEnumerable<CategoryFormModelView> Categories { get; set; } = new List<CategoryFormModelView>();
    }
}
