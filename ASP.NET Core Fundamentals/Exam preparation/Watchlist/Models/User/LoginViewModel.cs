using System.ComponentModel.DataAnnotations;
using static Watchlist.GlobalConstants.DataConstants.User;
using static Watchlist.GlobalConstants.ErrorMessages;

namespace Watchlist.Models.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = StringLengthErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set;} = null!;
    }
}
