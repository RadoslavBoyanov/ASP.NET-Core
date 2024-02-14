using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Contacts.GlobalConstants.DataConstants.Contact;

namespace Contacts.Data.Models
{
    /// <summary>
    /// class Contact
    /// </summary>
    public class Contact
    {
        [Key]
        [Comment("Contact id")]
        public int Id { get; set; }

        [Required]
        [StringLength(ContactFirstNameMaxLength)]
        [Column("First name")]
        [Comment("Contact first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(ContactLastNameMaxLength)]
        [Column("Last name")]
        [Comment("Contact last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(ContactEmailMaxLength)]
        [Comment("Contact email")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(ContactPhoneNumberMaxLength)]
        [Column("Phone number")]
        [Comment("Contact phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Comment("Contact address")]
        public string? Address { get; set; }

        [Required]
        public string Website { get; set; } = string.Empty;

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();
    }
}
