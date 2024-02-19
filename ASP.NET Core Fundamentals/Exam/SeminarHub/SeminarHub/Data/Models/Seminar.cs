using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SeminarHub.GlobalConstants.DataConstants.Seminar;

namespace SeminarHub.Data.Models
{
    /// <summary>
    /// Class for seminars 
    /// </summary>
    public class Seminar
    {
        [Key]
        [Comment("Seminar id")]
        public int Id { get; set; }

        [Required]
        [StringLength(TopicMaxLength)]
        [Comment("Seminar topic")]
        public string Topic { get; set; } = string.Empty;

        [Required]
        [StringLength(LecturerMaxLength)]
        [Comment("Seminar lecturer")]
        public string Lecturer { get; set; } = string.Empty;

        [Required]
        [StringLength(DetailsMaxLength)]
        [Comment("Seminar details")]
        public string Details { get; set; } = string.Empty;

        [Required]
        [Comment("Navigation property for user")]
        public string OrganizerId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OrganizerId))] 
        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        [Comment("Seminar dates")]
        public DateTime DateAndTime { get; set; }

        [Range(DurationMinRange, DurationMaxRange)]
        [Comment("Seminar duration")]
        public int? Duration { get; set; }

        [Required]
        [Comment("Navigation property for category")]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Comment("Collection for participants in seminars")]
        public ICollection<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
    }
}
