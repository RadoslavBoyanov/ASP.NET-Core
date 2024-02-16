using System.ComponentModel.DataAnnotations;
using static Watchlist.GlobalConstants.DataConstants.User;
using static Watchlist.GlobalConstants.ErrorMessages;

namespace Watchlist.Models.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "User")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = StringLengthErrorMessage)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = StringLengthErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
