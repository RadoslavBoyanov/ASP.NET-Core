using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatLovers.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatLovers.Infrastructure.Data.Configurations
{
	public class SubFamilyConfiguration : IEntityTypeConfiguration<SubFamily>
	{
		public void Configure(EntityTypeBuilder<SubFamily> builder)
		{
			builder.HasData(this.GenerateSubFamilies());
		}

		private SubFamily[] GenerateSubFamilies()
		{
			ICollection<SubFamily> subFamilies = new HashSet<SubFamily>();

			SubFamily subFamily;

			subFamily = new SubFamily()
			{
				Id = 1,
				Name = "Felinae",
				Description =
					"Felinae is a subfamily of the Felidae and comprises the small cats having a bony hyoid, because of which they are able to purr but not roar. Other authors have proposed an alternative definition for this subfamily, as comprising only the living conical-toothed cat genera with two tribes, the Felini and Pantherini, and excluding the extinct sabre-toothed Machairodontinae. The members of the Felinae have retractile claws that are protected by at least one cutaneous lobe. Their larynx is kept close to the base of the skull by an ossified hyoid. They can purr owing to the vocal folds being shorter than 6 mm (0.24 in). The cheetah Acinonyx does not have cutaneous sheaths for guarding claws.",
				FamilyId = 1,
			};
			subFamilies.Add(subFamily);

			subFamily = new SubFamily()
			{
				Id = 2,
				Name = "Pantherinae",
				Description =
					"The Pantherinae is a subfamily of the Felidae; it was named and first described by Reginald Innes Pocock in 1917 as only including the Panthera species. The Pantherinae genetically diverged from a common ancestor between 9.32 to 4.47 million years ago and 10.67 to 3.76 million years ago. Pantherinae species are characterised by an imperfectly ossified hyoid bone with elastic tendons that enable their larynx to be mobile.[2] They have a flat rhinarium that only barely reaches the dorsal side of the nose. The area between the nostrils is narrow, and not extended sidewards as in the Felinae.\r\n\r\nThe Panthera species have a single, rounded, vocal fold with a thick mucosal lining, a large vocalis muscle, and a large cricothyroid muscle with long and narrow membranes. A vocal fold that is longer than 19 mm (0.75 in) enables all but the snow leopard among them to roar, as it has shorter vocal folds of 9 mm (0.35 in) that provide a lower resistance to airflow; this distinction was one reason it was proposed to be retained in the genus Uncia.",
				FamilyId = 1,
			};
			subFamilies.Add(subFamily);

			return subFamilies.ToArray();
		}
	}
}
