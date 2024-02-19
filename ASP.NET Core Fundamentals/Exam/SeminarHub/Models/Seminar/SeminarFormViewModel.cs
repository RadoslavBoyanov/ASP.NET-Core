using SeminarHub.Models.Category;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.GlobalConstants.DataConstants.Seminar;
using static SeminarHub.GlobalConstants.ErrorMessages;

namespace SeminarHub.Models.Seminar
{
    /// <summary>
    /// View model for Add and edit method
    /// </summary>
    public class SeminarFormViewModel
    {

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(TopicMaxLength, MinimumLength = TopicMinLength, ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Seminar Topic")]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(LecturerMaxLength, MinimumLength = LecturerMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(DetailsMaxLength, MinimumLength = DetailsMinLength, ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "More Info")]
        public string Details { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date of Seminar")]
        public string DateAndTime { get; set; } = string.Empty;

        [Range(DurationMinRange, DurationMaxRange)]
        public int? Duration { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
