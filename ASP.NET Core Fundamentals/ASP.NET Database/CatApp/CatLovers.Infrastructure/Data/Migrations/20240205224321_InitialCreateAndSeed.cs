using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatLovers.Infrastructure.Data.Migrations
{
    public partial class InitialCreateAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for the family entity.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the family."),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Description for subfamily, characteristic and common information.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for the subfamily entity.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the subfamily."),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Description for subfamily, characteristic and common information."),
                    FamilyId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property to the parent family entity.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFamilies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubFamilies_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for the genus entity.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the genus."),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Description for genus, characteristic and common information."),
                    SubFamilyId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property to the parent Subfamily entity.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genera_SubFamilies_SubFamilyId",
                        column: x => x.SubFamilyId,
                        principalTable: "SubFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for the species entity.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the species."),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Description for species, characteristic and common information."),
                    StatusSpecies = table.Column<int>(type: "int", nullable: false, comment: "Status of species/subspecies for that is a risk for existence."),
                    DistributionAndHabitat = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Distribution and habitat refer to the geographical range and the specific environment where a particular species or group of organisms can be found."),
                    EcologyAndBehaviour = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Behavior and ecology are interconnected aspects of the study of organisms, shedding light on how they interact with their environment and other members of their species."),
                    Threats = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Animals face various threats that impact their survival and well-being. These threats can be natural, but increasingly, human activities are posing significant challenges to many species."),
                    GenusId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property to the parent Genus entity.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Genera_GenusId",
                        column: x => x.GenusId,
                        principalTable: "Genera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for the subpecies entity.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the subspecies."),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Description for subspecies, characteristic and common information."),
                    StatusSpecies = table.Column<int>(type: "int", nullable: false, comment: "Status of species/subspecies for that is a risk for existence."),
                    DistributionAndHabitat = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Distribution and habitat refer to the geographical range and the specific environment where a particular species or group of organisms can be found."),
                    EcologyAndBehaviour = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Behavior and ecology are interconnected aspects of the study of organisms, shedding light on how they interact with their environment and other members of their species."),
                    Threats = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Animals face various threats that impact their survival and well-being. These threats can be natural, but increasingly, human activities are posing significant challenges to many species."),
                    SpeciesId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property to the parent Species entity.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSpecies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Felidae  is the family of mammals in the order Carnivora colloquially referred to as cats. A member of this family is also called a felid . The term \"cat\" refers both to felids in general and specifically to the domestic cat (Felis catus).", "Felidae" });

            migrationBuilder.InsertData(
                table: "SubFamilies",
                columns: new[] { "Id", "Description", "FamilyId", "Name" },
                values: new object[] { 1, "Felinae is a subfamily of the Felidae and comprises the small cats having a bony hyoid, because of which they are able to purr but not roar. Other authors have proposed an alternative definition for this subfamily, as comprising only the living conical-toothed cat genera with two tribes, the Felini and Pantherini, and excluding the extinct sabre-toothed Machairodontinae. The members of the Felinae have retractile claws that are protected by at least one cutaneous lobe. Their larynx is kept close to the base of the skull by an ossified hyoid. They can purr owing to the vocal folds being shorter than 6 mm (0.24 in). The cheetah Acinonyx does not have cutaneous sheaths for guarding claws.", 1, "Felinae" });

            migrationBuilder.InsertData(
                table: "SubFamilies",
                columns: new[] { "Id", "Description", "FamilyId", "Name" },
                values: new object[] { 2, "The Pantherinae is a subfamily of the Felidae; it was named and first described by Reginald Innes Pocock in 1917 as only including the Panthera species. The Pantherinae genetically diverged from a common ancestor between 9.32 to 4.47 million years ago and 10.67 to 3.76 million years ago. Pantherinae species are characterised by an imperfectly ossified hyoid bone with elastic tendons that enable their larynx to be mobile.[2] They have a flat rhinarium that only barely reaches the dorsal side of the nose. The area between the nostrils is narrow, and not extended sidewards as in the Felinae.\r\n\r\nThe Panthera species have a single, rounded, vocal fold with a thick mucosal lining, a large vocalis muscle, and a large cricothyroid muscle with long and narrow membranes. A vocal fold that is longer than 19 mm (0.75 in) enables all but the snow leopard among them to roar, as it has shorter vocal folds of 9 mm (0.35 in) that provide a lower resistance to airflow; this distinction was one reason it was proposed to be retained in the genus Uncia.", 1, "Pantherinae" });

            migrationBuilder.InsertData(
                table: "Genera",
                columns: new[] { "Id", "Description", "Name", "SubFamilyId" },
                values: new object[,]
                {
                    { 1, "Caracal is a genus in the subfamily Felinae of the family Felidae. It was proposed by John Edward Gray in 1843 who described a skin from the Cape of Good Hope in the collection of the Natural History Museum, London. Historically, it was considered to be a monotypic genus, consisting of only the type species: the caracal C. caracal.", "Caracal", 1 },
                    { 2, "The serval (Leptailurus serval) is a wild cat native to Africa. It is widespread in sub-Saharan countries, except rainforest regions. Across its range, it occurs in protected areas, and hunting it is either prohibited or regulated in range countries.", "Leptailurus serval", 1 },
                    { 3, "Leopardus is a genus comprising eight species of small cats native to the Americas. This genus is considered the oldest branch of a genetic lineage of small cats in the Americas whose common ancestor crossed the Bering land bridge from Asia to North America in the late Miocene.Leopardus species have spotted fur, with ground colors ranging from pale buff, ochre, fulvous and tawny to light gray. Their small ears are rounded and white-spotted; their rhinarium is prominent and naked above, and their nostrils are widely separated. They have 36 chromosomes, whereas other felids have 38.", "Leopardus", 1 },
                    { 4, "Catopuma is a genus of the Felidae containing two small cat species native to Southeast Asia, the Asian golden cat (C. temminckii) and the bay cat (C. badia). Both have similar pelage, with solid reddish brown coloration on their backs and darker markings on the head. They also exhibit colour morphs ranging from various browns to gray to black. The Asian golden cat occurs from northeast India to Sumatra, and the bay cat lives only on Borneo. Both inhabit forested areas.\r\n\r\nThe closest living relative of Catopuma is the marbled cat (Pardofelis marmorata), from which the common ancestor of Catopuma genetically diverged around 9.4 million years ago. The Asian golden cat and bay cat diverged from one another approximately 3.16 million years ago, before Borneo separated from the neighboring islands.", "Catopuma", 1 },
                    { 5, "Pardofelis is a genus of the cat family Felidae. This genus is defined as including one species native to Southeast Asia: the marbled cat. Two other species, formerly classified to this genus, now belong to the genus Catopuma.\r\n\r\nThe word pardofelis is composed of the Latin words pardus (pard), and felis (cat) in allusion to the spots of the type species, the marbled cat.", "Pardofelis", 1 },
                    { 6, "A lynx  is any of the four extant species (the Canada lynx, Iberian lynx, Eurasian lynx and the bobcat) within the medium-sized wild cat genus Lynx. The name originated in Middle English via Latin from the Greek word lynx , derived from the Indo-European root leuk- (\"light\", \"brightness\") in reference to the luminescence of its reflective eyes. Lynx have a short tail, characteristic tufts of black hair on the tips of their ears, large, padded paws for walking on snow and long whiskers on the face. Under their neck, they have a ruff, which has black bars resembling a bow tie, although this is often not visible.\r\n\r\nBody colour varies from medium brown to goldish to beige-white, and is occasionally marked with dark brown spots, especially on the limbs. All species of lynx have white fur on their chests, bellies and on the insides of their legs, fur which is an extension of the chest and belly fur. The lynx's colouring, fur length and paw size vary according to the climate in their range. In the Southwestern United States, they are short-haired, dark in colour and their paws are smaller and less padded. As climates get colder and more northerly, lynx have progressively thicker fur, lighter colour, and their paws are larger and more padded to adapt to the snow.\r\n\r\nThe smallest species are the bobcat and the Canada lynx, while the largest is the Eurasian lynx, with considerable variations within species.", "Lynx", 1 },
                    { 7, "Puma is a genus in the family Felidae whose only extant species is the cougar (also known as the puma, mountain lion, and panther, among other names), and may also include several poorly known Old World fossil representatives (for example, Puma pardoides, or Owen's panther, a large, cougar-like cat of Eurasia's Pliocene).In addition to these potential Old World fossils, a few New World fossil representatives are possible, such as Puma pumoides[5] and the two species of the so-called \"American cheetah\", currently classified under the genus Miracinonyx. Pumas are large, secretive cats. They are also commonly known as cougars and mountain lions, and are able to reach larger sizes than some other \"big\" cat individuals. Despite their large size, they are more closely related to smaller feline species than to lions or leopards. The two subspecies of pumas have similar characteristics but tend to vary in color and size. Pumas are the most adaptable felines in the Americas and are found in a variety of different habitats, unlike other cat species.", "Puma", 1 },
                    { 8, "Acinonyx is a genus within the Felidae family. The only living species of the genus, the cheetah (A. jubatus), lives in open grasslands of Africa and Asia.\r\n\r\nSeveral fossil remains of cheetah-like cats were excavated that date to the late Pliocene and Middle Pleistocene. These cats occurred in Africa, parts of Europe and Asia about 10,000 years ago. Several similar species classified in the genus Miracinonyx lived in North America at the same time; these may have been more closely related to the genus Puma.", "Acinonyx", 1 },
                    { 9, "Prionailurus is a genus of spotted, small wild cats native to Asia. Forests are their preferred habitat; they feed on small mammals, reptiles and birds, and occasionally aquatic wildlife.The British zoologist Reginald Innes Pocock recognized the taxonomic classification of Prionailurus in 1917. In 1939, he described the genus on the basis of skins and skulls, and compared these to body parts of Felis. Prionailurus species are marked with spots, which are frequently lanceolate, sometimes rosette-like, and occasionally tend to run into longitudinal chains, but never fuse to form vertical stripes as in Felis. Skulls of Prionailurus are lower and less vaulted than of Felis. The facial part is shorter than the cranial, and the bottom of the orbit longer. The nasal bones are not everted above the anterior nares, and the outer chamber of the bulla is much smaller than the inner. Pocock classified the leopard cat, rusty-spotted cat and fishing cat as belonging to the genus Prionailurus.", "Prionailurus", 1 },
                    { 10, "The manul (Otocolobus manul) is a medium-sized species of predator from the Felidae family, separated into a separate genus \"Otocolobus\" (from Greek: \"oto\" - ear and \"kολοβός\" - shortened, incomplete, missing; translates as \"Short ear\" ). It is also called Pallas's cat in honor of the naturalist Peter Simon Pallas who described it.", "Otocolobus manul", 1 },
                    { 11, "Jaguarundi (Puma yagouaroundi), separated into a separate genus Herpailurus, is a predator from the Cat family. Recent genetic studies prove its close kinship with the cougar.", "Jaguarundi", 1 },
                    { 12, "Felis is a genus of small and medium-sized cat species native to most of Africa and south of 60° latitude in Europe and Asia to Indochina. The genus includes the domestic cat. The smallest Felis species is the black-footed cat with a head and body length from 38 to 42 cm (15 to 17 in). The largest is the jungle cat with a head and body length from 62 to 76 cm (24 to 30 in).\r\n\r\nGenetic studies indicate that the Felinae genera Felis, Otocolobus and Prionailurus diverged from a Eurasian progenitor of the Felidae about 6.2 million years ago, and that Felis species split off 3.04 to 0.99 million years ago.", "Felis", 1 },
                    { 13, "Panthera is a genus within the family Felidae that was named and described by Lorenz Oken in 1816 who placed all the spotted cats in this group. Reginald Innes Pocock revised the classification of this genus in 1916 as comprising the tiger (P. tigris), lion (P. leo), jaguar (P. onca), and leopard (P. pardus) on the basis of common features of their skulls.[4] Results of genetic analysis indicate that the snow leopard (formerly Uncia uncia) also belongs to the genus Panthera (P. uncia), a classification that was accepted by IUCN Red List assessors in 2008. In Panthera species, the dorsal profile of the skull is flattish or evenly convex. The frontal interorbital area is not noticeably elevated, and the area behind the elevation is less steeply sloped. The basic cranial axis is nearly horizontal. The inner chamber of the bullae is large, the outer small. The partition between them is close to the external auditory meatus. The convexly rounded chin is sloping. All Panthera species have an incompletely ossified hyoid bone and a specially adapted larynx with large vocal folds covered in a fibro-elastic pad; these characteristics enable them to roar. Only the snow leopard cannot roar, as it has shorter vocal folds of 9 mm (0.35 in) that provide a lower resistance to airflow; it was therefore proposed to be retained in the genus Uncia. Panthera species can prusten, which is a short, soft, snorting sound; it is used during contact between friendly individuals. The roar is an especially loud call with a distinctive pattern that depends on the species.", "Panthera", 2 },
                    { 14, "Neofelis is a genus comprising two extant cat species in Southeast Asia: the clouded leopard (Neofelis nebulosa) of mainland Asia, and the Sunda clouded leopard (Neofelis diardi) of Sumatra and Borneo.\r\n\r\nThe scientific name Neofelis is a composite of the Greek word neo- (νέος-) meaning 'young' and 'new', and the Latin word fēles meaning 'cat'. Gray described the genus Neofelis as having an elongate skull, a broad and rather produced face on the same plane as the forehead, a large and elongate nasal, a moderate orbit, a truncated lower jaw and very long conical upper and lower canine teeth with a sharp cutting hinder edge. This skull has resemblances to that of the fossil Smilodon, with very much elongated upper canines.Pocock described the skull of Neofelis as recalling in general features that of Panthera pardus, especially in the shortness and wide separation of the frontal and malar postorbital processes, relative proportion of mandibular teeth; but differing in the greater posterior width of the nasals, the thicker, more salient inferior edge of the orbit, and the mandible being greatly elevated anteriorly. As a result of this unusual skull anatomy, neofelids have a maximum gape of approximately 90 degrees, the biggest of extant carnivora, a trait shared by the extinct Machairodontinae subfamily.\r\n\r\nThe Sunda clouded leopard has longer upper canine teeth and a narrower palate between them.", "Neofelis", 2 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Description", "DistributionAndHabitat", "EcologyAndBehaviour", "GenusId", "Name", "StatusSpecies", "Threats" },
                values: new object[] { 1, "The African golden cat (Caracal aurata) is a wild cat endemic to the rainforests of West and Central Africa. It is threatened due to deforestation and bushmeat hunting and listed as Vulnerable on the IUCN Red List. It is a close relative of both the caracal and the serval.Previously, it was placed in the genus Profelis. Its body size ranges from 61 to 101 cm (24 to 40 in) with a 16 to 46 cm (6.3 to 18.1 in) long tail. The African golden cat has a fur colour ranging from chestnut or reddish-brown, greyish brown to dark slaty. Some are spotted, with the spots ranging from faded tan to black in colour. In others the spotting pattern is limited to the belly and inner legs. Its undersides and areas around the eyes, cheeks, chin, and throat are lighter in colour to almost white. Its tail is darker on the top and either heavily banded, lightly banded or plain, ending in a black tip. Cats in the western parts of its range tend to have heavier spotting than those in the eastern region. Two color morphs, a red and a grey phase, were once thought to indicate separate species, rather than colour variations of the same species. Grey skins have hairs that are not pigmented in their middle zones, whereas hair of red skins is pigmented intensively red. Hair of melanistic skins is entirely black.\r\n\r\nSkins of African golden cats can be identified by the presence of a distinctive whorled ridge of fur in front of the shoulders, where the hairs change direction. It is about twice the size of a domestic cat. Its rounded head is very small in relation to its body size. It is a heavily built cat, with stocky, long legs, a relatively short tail, and large paws. Body length usually varies within the range of 61 to 101 cm (24 to 40 in). Tail length ranges from 16 to 46 cm (6.3 to 18.1 in), and shoulder height is about 38 to 55 cm (15 to 22 in). The cat weighs around 5.5 to 16 kg (12 to 35 lb), with males being larger than females.\r\n\r\nOverall, the African golden cat resembles the caracal, but has shorter untufted ears, a longer tail, and a shorter, more rounded face. It has small, rounded ears. Its eye colour ranges from pale blue to brown.", "The African golden cat is distributed from Senegal to the Central African Republic, Kenya and as far south as northern Angola. It inhabits tropical forests from sea level to an elevation of 3,000 m (9,800 ft). It prefers dense, moist forest with heavy undergrowth close to rivers but lives also in cloud forest, bamboo forests, and high moorland habitats.\r\n\r\nIn Guinea's National Park of Upper Niger, it was recorded during surveys conducted in 1996 to 1997.\r\n\r\nIn Uganda's Kibale National Park, an African golden cat was recorded in an Uvariopsis forest patch in 2008. In Gabon's Moukalaba-Doudou National Park, it was recorded in forested areas during surveys in 2012. African Golden cats were recorded in Tanzania's Minziro Forest Reserve in 2018 for the first time.", "Due to its extremely reclusive habits, little is known about the behaviour of African golden cats. They are solitary animals, and are normally crepuscular or nocturnal, although they have also been observed hunting during the day, depending on the availability of local prey.\r\n\r\nAfrican golden cats are able to climb, but hunt primarily on the ground. They mainly feed on tree hyrax, rodents, but also hunt birds, small monkeys, duikers, young of giant forest hog, and small antelope. They have also been known to take domestic poultry and livestock.", 1, "African golden cat", 0, "The African golden cat is threatened by extensive deforestation of tropical rainforests, their conversion to oil palm plantations coupled with mining activities and road building, thus destroying its essential habitat. It is also threatened by bushmeat hunting, particularly in the Congo Basin. A dead African golden cat was offered as bushmeat in Angola's Uíge Province in May 2018." });

            migrationBuilder.CreateIndex(
                name: "IX_Genera_SubFamilyId",
                table: "Genera",
                column: "SubFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_GenusId",
                table: "Species",
                column: "GenusId");

            migrationBuilder.CreateIndex(
                name: "IX_SubFamilies_FamilyId",
                table: "SubFamilies",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSpecies_SpeciesId",
                table: "SubSpecies",
                column: "SpeciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubSpecies");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Genera");

            migrationBuilder.DropTable(
                name: "SubFamilies");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
