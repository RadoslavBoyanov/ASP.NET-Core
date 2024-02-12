using System.ComponentModel.DataAnnotations;
using static Homies.GlobalConstants.ErrorMessages;

namespace Homies.Models
{
    public class EventFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(GlobalConstants.EntityValidations.Event.EventNameMaxLength,
            MinimumLength = GlobalConstants.EntityValidations.Event.EventNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(GlobalConstants.EntityValidations.Event.EventDescriptionMaxLength,
            MinimumLength = GlobalConstants.EntityValidations.Event.EventDescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string Start { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string End { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
