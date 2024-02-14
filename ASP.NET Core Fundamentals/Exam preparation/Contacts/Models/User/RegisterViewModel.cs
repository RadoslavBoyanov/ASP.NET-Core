﻿using System.ComponentModel.DataAnnotations;
using static Contacts.GlobalConstants.DataConstants.ApplicationUser;
using static Contacts.GlobalConstants.ErrorMessages;

namespace Contacts.Models.User
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Username")]
        [StringLength(ApplicationUserNameMaxLength, MinimumLength = ApplicationUserNameMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [EmailAddress]
        [StringLength(ApplicationUserEmailMaxLength, MinimumLength = ApplicationUserEmailMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(ApplicationUserPasswordMaxLength, MinimumLength = ApplicationUserPasswordMinLength, ErrorMessage = StringLengthErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
