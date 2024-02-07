using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CatLovers.Infrastructure.Common.Enum;
using Microsoft.EntityFrameworkCore;
using static Cat.Lovers.Common.GlobalConstants.EntityValidations.Common;

namespace CatLovers.Infrastructure.Models
{
	public class Species
	{
		public Species()
		{
			this.SubSpecies = new HashSet<SubSpecies>();
			this.StatusSpecies = StatusSpecies.nonТhreatened;
		}

		[Key]
		[Comment("Primary key for the species entity.")]
		public int Id { get; set; }

		[Required]
		[StringLength(StringLengthName)]
		[Comment("The name of the species.")]
		public string Name { get; set; } = string.Empty;

		[Required]
		[StringLength(StringLengthDescription)]
		[Comment("Description for species, characteristic and common information.")]
		public string Description { get; set; } = string.Empty;

		[Comment("Status of species/subspecies for that is a risk for existence.")]
		public StatusSpecies StatusSpecies { get; set; }

		[Comment("Distribution and habitat refer to the geographical range and the specific environment where a particular species or group of organisms can be found.")]
		public string DistributionAndHabitat { get; set; } = string.Empty;

		[Comment("Behavior and ecology are interconnected aspects of the study of organisms, shedding light on how they interact with their environment and other members of their species.")]
		public string EcologyAndBehaviour { get; set; } = string.Empty;

		[Comment("Animals face various threats that impact their survival and well-being. These threats can be natural, but increasingly, human activities are posing significant challenges to many species.")]
		public string Threats { get; set; } = string.Empty;

		[ForeignKey(nameof(Genus))]
		[Comment("Navigation property to the parent Genus entity.")]
		public int GenusId { get; set; }
		public Genus Genus { get; set; }

		public ICollection<SubSpecies> SubSpecies { get; set; }
	}
}
