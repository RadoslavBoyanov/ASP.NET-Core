using CatLovers.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatLovers.Infrastructure.Data.Configurations
{
	public class GenusConfiguration : IEntityTypeConfiguration<Genus>
	{
		public void Configure(EntityTypeBuilder<Genus> builder)
		{
			builder.HasData(this.GenerateGenera());
		}

		private Genus[] GenerateGenera()
		{
			ICollection<Genus> genera = new HashSet<Genus>();

			Genus genus;

			genus = new Genus()
			{
				Id = 1,
				Name = "Caracal",
				Description = "Caracal is a genus in the subfamily Felinae of the family Felidae. It was proposed by John Edward Gray in 1843 who described a skin from the Cape of Good Hope in the collection of the Natural History Museum, London. Historically, it was considered to be a monotypic genus, consisting of only the type species: the caracal C. caracal.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 2,
				Name = "Leptailurus serval",
				Description =
					"The serval (Leptailurus serval) is a wild cat native to Africa. It is widespread in sub-Saharan countries, except rainforest regions. Across its range, it occurs in protected areas, and hunting it is either prohibited or regulated in range countries.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 3,
				Name = "Leopardus",
				Description =
					"Leopardus is a genus comprising eight species of small cats native to the Americas. This genus is considered the oldest branch of a genetic lineage of small cats in the Americas whose common ancestor crossed the Bering land bridge from Asia to North America in the late Miocene.Leopardus species have spotted fur, with ground colors ranging from pale buff, ochre, fulvous and tawny to light gray. Their small ears are rounded and white-spotted; their rhinarium is prominent and naked above, and their nostrils are widely separated. They have 36 chromosomes, whereas other felids have 38.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 4,
				Name = "Catopuma",
				Description =
					"Catopuma is a genus of the Felidae containing two small cat species native to Southeast Asia, the Asian golden cat (C. temminckii) and the bay cat (C. badia). Both have similar pelage, with solid reddish brown coloration on their backs and darker markings on the head. They also exhibit colour morphs ranging from various browns to gray to black. The Asian golden cat occurs from northeast India to Sumatra, and the bay cat lives only on Borneo. Both inhabit forested areas.\r\n\r\nThe closest living relative of Catopuma is the marbled cat (Pardofelis marmorata), from which the common ancestor of Catopuma genetically diverged around 9.4 million years ago. The Asian golden cat and bay cat diverged from one another approximately 3.16 million years ago, before Borneo separated from the neighboring islands.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 5,
				Name = "Pardofelis",
				Description = "Pardofelis is a genus of the cat family Felidae. This genus is defined as including one species native to Southeast Asia: the marbled cat. Two other species, formerly classified to this genus, now belong to the genus Catopuma.\r\n\r\nThe word pardofelis is composed of the Latin words pardus (pard), and felis (cat) in allusion to the spots of the type species, the marbled cat.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 6,
				Name = "Lynx",
				Description = "A lynx  is any of the four extant species (the Canada lynx, Iberian lynx, Eurasian lynx and the bobcat) within the medium-sized wild cat genus Lynx. The name originated in Middle English via Latin from the Greek word lynx , derived from the Indo-European root leuk- (\"light\", \"brightness\") in reference to the luminescence of its reflective eyes. Lynx have a short tail, characteristic tufts of black hair on the tips of their ears, large, padded paws for walking on snow and long whiskers on the face. Under their neck, they have a ruff, which has black bars resembling a bow tie, although this is often not visible.\r\n\r\nBody colour varies from medium brown to goldish to beige-white, and is occasionally marked with dark brown spots, especially on the limbs. All species of lynx have white fur on their chests, bellies and on the insides of their legs, fur which is an extension of the chest and belly fur. The lynx's colouring, fur length and paw size vary according to the climate in their range. In the Southwestern United States, they are short-haired, dark in colour and their paws are smaller and less padded. As climates get colder and more northerly, lynx have progressively thicker fur, lighter colour, and their paws are larger and more padded to adapt to the snow.\r\n\r\nThe smallest species are the bobcat and the Canada lynx, while the largest is the Eurasian lynx, with considerable variations within species.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 7,
				Name = "Puma",
				Description = "Puma is a genus in the family Felidae whose only extant species is the cougar (also known as the puma, mountain lion, and panther, among other names), and may also include several poorly known Old World fossil representatives (for example, Puma pardoides, or Owen's panther, a large, cougar-like cat of Eurasia's Pliocene).In addition to these potential Old World fossils, a few New World fossil representatives are possible, such as Puma pumoides[5] and the two species of the so-called \"American cheetah\", currently classified under the genus Miracinonyx. Pumas are large, secretive cats. They are also commonly known as cougars and mountain lions, and are able to reach larger sizes than some other \"big\" cat individuals. Despite their large size, they are more closely related to smaller feline species than to lions or leopards. The two subspecies of pumas have similar characteristics but tend to vary in color and size. Pumas are the most adaptable felines in the Americas and are found in a variety of different habitats, unlike other cat species.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 8,
				Name = "Acinonyx",
				Description = "Acinonyx is a genus within the Felidae family. The only living species of the genus, the cheetah (A. jubatus), lives in open grasslands of Africa and Asia.\r\n\r\nSeveral fossil remains of cheetah-like cats were excavated that date to the late Pliocene and Middle Pleistocene. These cats occurred in Africa, parts of Europe and Asia about 10,000 years ago. Several similar species classified in the genus Miracinonyx lived in North America at the same time; these may have been more closely related to the genus Puma.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 9,
				Name = "Prionailurus",
				Description = "Prionailurus is a genus of spotted, small wild cats native to Asia. Forests are their preferred habitat; they feed on small mammals, reptiles and birds, and occasionally aquatic wildlife.The British zoologist Reginald Innes Pocock recognized the taxonomic classification of Prionailurus in 1917. In 1939, he described the genus on the basis of skins and skulls, and compared these to body parts of Felis. Prionailurus species are marked with spots, which are frequently lanceolate, sometimes rosette-like, and occasionally tend to run into longitudinal chains, but never fuse to form vertical stripes as in Felis. Skulls of Prionailurus are lower and less vaulted than of Felis. The facial part is shorter than the cranial, and the bottom of the orbit longer. The nasal bones are not everted above the anterior nares, and the outer chamber of the bulla is much smaller than the inner. Pocock classified the leopard cat, rusty-spotted cat and fishing cat as belonging to the genus Prionailurus.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 10,
				Name = "Otocolobus manul",
				Description = "The manul (Otocolobus manul) is a medium-sized species of predator from the Felidae family, separated into a separate genus \"Otocolobus\" (from Greek: \"oto\" - ear and \"kολοβός\" - shortened, incomplete, missing; translates as \"Short ear\" ). It is also called Pallas's cat in honor of the naturalist Peter Simon Pallas who described it.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 11,
				Name = "Jaguarundi",
				Description = "Jaguarundi (Puma yagouaroundi), separated into a separate genus Herpailurus, is a predator from the Cat family. Recent genetic studies prove its close kinship with the cougar.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 12,
				Name = "Felis",
				Description = "Felis is a genus of small and medium-sized cat species native to most of Africa and south of 60° latitude in Europe and Asia to Indochina. The genus includes the domestic cat. The smallest Felis species is the black-footed cat with a head and body length from 38 to 42 cm (15 to 17 in). The largest is the jungle cat with a head and body length from 62 to 76 cm (24 to 30 in).\r\n\r\nGenetic studies indicate that the Felinae genera Felis, Otocolobus and Prionailurus diverged from a Eurasian progenitor of the Felidae about 6.2 million years ago, and that Felis species split off 3.04 to 0.99 million years ago.",
				SubFamilyId = 1
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 13,
				Name = "Panthera",
				Description = "Panthera is a genus within the family Felidae that was named and described by Lorenz Oken in 1816 who placed all the spotted cats in this group. Reginald Innes Pocock revised the classification of this genus in 1916 as comprising the tiger (P. tigris), lion (P. leo), jaguar (P. onca), and leopard (P. pardus) on the basis of common features of their skulls.[4] Results of genetic analysis indicate that the snow leopard (formerly Uncia uncia) also belongs to the genus Panthera (P. uncia), a classification that was accepted by IUCN Red List assessors in 2008. In Panthera species, the dorsal profile of the skull is flattish or evenly convex. The frontal interorbital area is not noticeably elevated, and the area behind the elevation is less steeply sloped. The basic cranial axis is nearly horizontal. The inner chamber of the bullae is large, the outer small. The partition between them is close to the external auditory meatus. The convexly rounded chin is sloping. All Panthera species have an incompletely ossified hyoid bone and a specially adapted larynx with large vocal folds covered in a fibro-elastic pad; these characteristics enable them to roar. Only the snow leopard cannot roar, as it has shorter vocal folds of 9 mm (0.35 in) that provide a lower resistance to airflow; it was therefore proposed to be retained in the genus Uncia. Panthera species can prusten, which is a short, soft, snorting sound; it is used during contact between friendly individuals. The roar is an especially loud call with a distinctive pattern that depends on the species.",
				SubFamilyId = 2
			};
			genera.Add(genus);

			genus = new Genus()
			{
				Id = 14,
				Name = "Neofelis",
				Description =
					"Neofelis is a genus comprising two extant cat species in Southeast Asia: the clouded leopard (Neofelis nebulosa) of mainland Asia, and the Sunda clouded leopard (Neofelis diardi) of Sumatra and Borneo.\r\n\r\nThe scientific name Neofelis is a composite of the Greek word neo- (νέος-) meaning 'young' and 'new', and the Latin word fēles meaning 'cat'. Gray described the genus Neofelis as having an elongate skull, a broad and rather produced face on the same plane as the forehead, a large and elongate nasal, a moderate orbit, a truncated lower jaw and very long conical upper and lower canine teeth with a sharp cutting hinder edge. This skull has resemblances to that of the fossil Smilodon, with very much elongated upper canines.Pocock described the skull of Neofelis as recalling in general features that of Panthera pardus, especially in the shortness and wide separation of the frontal and malar postorbital processes, relative proportion of mandibular teeth; but differing in the greater posterior width of the nasals, the thicker, more salient inferior edge of the orbit, and the mandible being greatly elevated anteriorly. As a result of this unusual skull anatomy, neofelids have a maximum gape of approximately 90 degrees, the biggest of extant carnivora, a trait shared by the extinct Machairodontinae subfamily.\r\n\r\nThe Sunda clouded leopard has longer upper canine teeth and a narrower palate between them.",
				SubFamilyId = 2
			};
			genera.Add(genus);


			return genera.ToArray();
		}
	}
}
