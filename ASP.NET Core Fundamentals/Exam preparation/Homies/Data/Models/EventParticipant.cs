using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    /// <summary>
    /// Mapping table many-to-many Event and Users
    /// </summary>
    public class EventParticipant
    {
        [Required]
        public string HelperId { get; set; }

        [ForeignKey(nameof(HelperId))] 
        public IdentityUser Helper { get; set; } = null!;

        [Required]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))] 
        public Event Event { get; set; } = null!;
    }
}
