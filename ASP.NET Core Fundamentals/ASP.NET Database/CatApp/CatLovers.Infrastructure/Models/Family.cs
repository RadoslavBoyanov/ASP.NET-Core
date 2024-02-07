using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Cat.Lovers.Common.GlobalConstants.EntityValidations.Common;

namespace CatLovers.Infrastructure.Models
{
	public class Family
	{
		public Family()
		{
			this.SubFamilies = new HashSet<SubFamily>();
		}

		[Key]
		[Comment("Primary key for the family entity.")]
		public int Id { get; set; }

		[Required]
		[StringLength(StringLengthName)]
		[Comment("The name of the family.")]
		public string Name { get; set; } = string.Empty;

		[Required]
		[StringLength(StringLengthDescription)]
		[Comment("Description for subfamily, characteristic and common information.")]
		public string Description { get; set; } = string.Empty;

		public ICollection<SubFamily> SubFamilies { get; set; }
	}
}
