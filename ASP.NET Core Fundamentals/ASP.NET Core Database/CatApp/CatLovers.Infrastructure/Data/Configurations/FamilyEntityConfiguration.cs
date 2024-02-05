using CatLovers.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatLovers.Infrastructure.Data.Configurations
{
	public class FamilyEntityConfiguration : IEntityTypeConfiguration<Family>
	{
		public void Configure(EntityTypeBuilder<Family> builder)
		{
			builder.HasData(this.GenerateFamily());
		}

		private Family[] GenerateFamily()
		{
			ICollection<Family> families = new HashSet<Family>();

			Family family;

			family = new Family()
			{
				Id = 1,
				Name = "Felidae",
				Description =
					"Felidae  is the family of mammals in the order Carnivora colloquially referred to as cats. A member of this family is also called a felid . The term \"cat\" refers both to felids in general and specifically to the domestic cat (Felis catus)."
			};
			families.Add(family);

			return families.ToArray();
		}
	}
}
