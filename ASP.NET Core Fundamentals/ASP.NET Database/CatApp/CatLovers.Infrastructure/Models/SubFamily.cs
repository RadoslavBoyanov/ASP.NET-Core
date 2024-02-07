using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Cat.Lovers.Common.GlobalConstants.EntityValidations.Common;

namespace CatLovers.Infrastructure.Models
{
	public class SubFamily
	{
		public SubFamily()
		{
			this.Genera = new HashSet<Genus>();
		}

		[Key]
		[Comment("Primary key for the subfamily entity.")]
		public int Id { get; set; }

		[Required]
		[StringLength(StringLengthName)]
		[Comment("The name of the subfamily.")]
		public string Name { get; set; } = string.Empty;

		[Required]
		[StringLength(StringLengthDescription)]
		[Comment("Description for subfamily, characteristic and common information.")]
		public string Description { get; set; } = string.Empty;

		[ForeignKey(nameof(Family))]
		[Comment("Navigation property to the parent family entity.")]
		public int FamilyId { get; set; }
		public Family Family { get; set; }

		public ICollection<Genus> Genera { get; set; }
	}
}
