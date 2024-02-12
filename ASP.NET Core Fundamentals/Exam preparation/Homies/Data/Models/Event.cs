using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Homies.GlobalConstants;

namespace Homies.Data.Models
{
    /// <summary>
    /// Class for Event
    /// </summary>
    public class Event
    {
        public Event()
        {
            this.EventParticipants = new List<EventParticipant>();
        }

        [Key]
        [Comment("Event id.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityValidations.Event.EventNameMaxLength)]
        [Comment("Event name.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(EntityValidations.Event.EventDescriptionMaxLength)]
        [Comment("Event description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Navigation property for user")]
        public string OrganiserId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OrganiserId))]
        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        [Comment("Event create date")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Event start date")]
        public DateTime Start { get; set; }

        [Required]
        [Comment("Event end date")]
        public DateTime End { get; set; }

        [Required]
        [Comment("Navigation property for Type")]
        public int TypeId { get; set; }
        [Required]
        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; } = null!;

        public ICollection<EventParticipant> EventParticipants { get; set; }
    }
}
