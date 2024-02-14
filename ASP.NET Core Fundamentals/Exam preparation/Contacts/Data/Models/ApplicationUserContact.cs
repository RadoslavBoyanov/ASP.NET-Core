using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.Models
{
    /// <summary>
    /// Many-to-many relation mapping table between ApplicationUser and contact 
    /// </summary>
    public class ApplicationUserContact
    {
        [Required]
        [Comment("Navigation property for application user")]
        public string ApplicationUserId  { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [Required]
        [Comment("Navigation property for contact")]
        public int ContactId { get; set; }

        [ForeignKey(nameof(ContactId))]
        public Contact Contact { get; set; } = null!;
    }
}
