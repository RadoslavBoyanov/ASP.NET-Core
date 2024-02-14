using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Contacts.GlobalConstants.DataConstants.ApplicationUser;

namespace Contacts.Data.Models
{
    /// <summary>
    /// Class for user who uses application
    /// </summary>
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [StringLength(ApplicationUserNameMaxLength)]
        [Column("User name ")]
        [Comment("User name")]
        public override string UserName
        {
            get => base.UserName;
            set => base.UserName = value;
        }

        [Required]
        [StringLength(ApplicationUserEmailMaxLength)]
        [Comment("User email")]
        public override string Email
        {
            get => base.Email;
            set => base.Email = value;
        }

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();
    }
}
