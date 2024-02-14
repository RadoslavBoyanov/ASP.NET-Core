using System.ComponentModel.DataAnnotations;
using static Contacts.GlobalConstants.DataConstants.Contact;
using static Contacts.GlobalConstants.ErrorMessages;

namespace Contacts.Models.Contacts
{
    /// <summary>
    /// Model view for Add and Edit
    /// </summary>
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(ContactFirstNameMaxLength, MinimumLength = ContactFirstNameMinLength, ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(ContactLastNameMaxLength, MinimumLength = ContactLastNameMinLength, ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [EmailAddress]
        [StringLength(ContactEmailMaxLength, MinimumLength = ContactEmailMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(ContactPhoneNumberMaxLength, MinimumLength = ContactPhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string Website { get; set; } = string.Empty;
    }
}
