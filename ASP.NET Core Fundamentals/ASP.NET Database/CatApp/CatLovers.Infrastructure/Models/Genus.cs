using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Cat.Lovers.Common.GlobalConstants.EntityValidations.Common;

namespace CatLovers.Infrastructure.Models
{
	public class Genus
	{
		public Genus()
		{
			this.SpeciesCollection = new HashSet<Species>();
		}

		[Key]
		[Comment("Primary key for the genus entity.")]
		public int Id { get; set; }

		[Required]
		[StringLength(StringLengthName)]
		[Comment("The name of the genus.")]
		public string Name { get; set; } = string.Empty;

		[Required]
		[StringLength(StringLengthDescription)]
		[Comment("Description for genus, characteristic and common information.")]
		public string Description { get; set; } = string.Empty;

		[ForeignKey(nameof(SubFamily))]
		[Comment("Navigation property to the parent Subfamily entity.")]
		public int SubFamilyId { get; set; }
		public SubFamily SubFamily { get; set; }

		public ICollection<Species> SpeciesCollection { get; set; }
	}
}
