using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Homies.GlobalConstants;

namespace Homies.Data.Models
{
    /// <summary>
    /// Class Type of Event
    /// </summary>
    public class Type
    {
        public Type()
        {
            this.Events = new List<Event>();
        }

        [Key]
        [Comment("Type id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityValidations.Type.TypeNameMaxLength)]
        [Comment("Type name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Collection of events")]
        public IEnumerable<Event> Events { get; set; }
    }
}
