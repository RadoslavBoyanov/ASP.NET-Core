using CatLovers.Infrastructure.Common.Enum;
using CatLovers.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatLovers.Infrastructure.Data.Configurations
{
	public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
	{
		public void Configure(EntityTypeBuilder<Species> builder)
		{
			builder.HasData(this.GenerateSpecies());
		}

		private Species[] GenerateSpecies()
		{
			ICollection<Species> species = new HashSet<Species>();

			Species newSpecies;

			newSpecies = new Species()
			{
				Id = 1,
				Name = "African golden cat",
				Description = "The African golden cat (Caracal aurata) is a wild cat endemic to the rainforests of West and Central Africa. It is threatened due to deforestation and bushmeat hunting and listed as Vulnerable on the IUCN Red List. It is a close relative of both the caracal and the serval.Previously, it was placed in the genus Profelis. Its body size ranges from 61 to 101 cm (24 to 40 in) with a 16 to 46 cm (6.3 to 18.1 in) long tail. The African golden cat has a fur colour ranging from chestnut or reddish-brown, greyish brown to dark slaty. Some are spotted, with the spots ranging from faded tan to black in colour. In others the spotting pattern is limited to the belly and inner legs. Its undersides and areas around the eyes, cheeks, chin, and throat are lighter in colour to almost white. Its tail is darker on the top and either heavily banded, lightly banded or plain, ending in a black tip. Cats in the western parts of its range tend to have heavier spotting than those in the eastern region. Two color morphs, a red and a grey phase, were once thought to indicate separate species, rather than colour variations of the same species. Grey skins have hairs that are not pigmented in their middle zones, whereas hair of red skins is pigmented intensively red. Hair of melanistic skins is entirely black.\r\n\r\nSkins of African golden cats can be identified by the presence of a distinctive whorled ridge of fur in front of the shoulders, where the hairs change direction. It is about twice the size of a domestic cat. Its rounded head is very small in relation to its body size. It is a heavily built cat, with stocky, long legs, a relatively short tail, and large paws. Body length usually varies within the range of 61 to 101 cm (24 to 40 in). Tail length ranges from 16 to 46 cm (6.3 to 18.1 in), and shoulder height is about 38 to 55 cm (15 to 22 in). The cat weighs around 5.5 to 16 kg (12 to 35 lb), with males being larger than females.\r\n\r\nOverall, the African golden cat resembles the caracal, but has shorter untufted ears, a longer tail, and a shorter, more rounded face. It has small, rounded ears. Its eye colour ranges from pale blue to brown.",
				EcologyAndBehaviour = "Due to its extremely reclusive habits, little is known about the behaviour of African golden cats. They are solitary animals, and are normally crepuscular or nocturnal, although they have also been observed hunting during the day, depending on the availability of local prey.\r\n\r\nAfrican golden cats are able to climb, but hunt primarily on the ground. They mainly feed on tree hyrax, rodents, but also hunt birds, small monkeys, duikers, young of giant forest hog, and small antelope. They have also been known to take domestic poultry and livestock.",
				DistributionAndHabitat = "The African golden cat is distributed from Senegal to the Central African Republic, Kenya and as far south as northern Angola. It inhabits tropical forests from sea level to an elevation of 3,000 m (9,800 ft). It prefers dense, moist forest with heavy undergrowth close to rivers but lives also in cloud forest, bamboo forests, and high moorland habitats.\r\n\r\nIn Guinea's National Park of Upper Niger, it was recorded during surveys conducted in 1996 to 1997.\r\n\r\nIn Uganda's Kibale National Park, an African golden cat was recorded in an Uvariopsis forest patch in 2008. In Gabon's Moukalaba-Doudou National Park, it was recorded in forested areas during surveys in 2012. African Golden cats were recorded in Tanzania's Minziro Forest Reserve in 2018 for the first time.",
				Threats = "The African golden cat is threatened by extensive deforestation of tropical rainforests, their conversion to oil palm plantations coupled with mining activities and road building, thus destroying its essential habitat. It is also threatened by bushmeat hunting, particularly in the Congo Basin. A dead African golden cat was offered as bushmeat in Angola's Uíge Province in May 2018.",
				StatusSpecies = StatusSpecies.endangered,
				GenusId = 1,
			};
			species.Add(newSpecies);

			return species.ToArray();
		}
	}
}
