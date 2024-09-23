using MyVeilleTechnoSoftware.Models;
using System.Text.Json;
using MyVeilleTechnoSoftware.Utils;
using System.Text.Json.Nodes;
using System.Xml;

namespace MyVeilleTechnoSoftware.Repository
{
    public static class LinksRepository
    {
        private static string pathLinksJson = "C:\\Users\\Thomas BDC\\source\\repos\\MyVeilleTechnoSoftware\\MyVeilleTechnoSoftware\\Data\\links.json";
        public static List<LinkModel> GetAllLinks()
        {
            List<LinkModel> allLinks = new List<LinkModel>();

            //Lire le fichier JSON, et le transformer en objet
            using (StreamReader r = new StreamReader(pathLinksJson))
            {
                string json = r.ReadToEnd();
                allLinks = JsonSerializer.Deserialize<List<LinkModel>>(json);
            }

            return allLinks;
        }

        public static void ProposeToUserToOpenLink(List<LinkModel> allLinks)
        {
            foreach (var link in allLinks)
            {
                Console.WriteLine(allLinks.IndexOf(link) + " : " + link.Title);
                Console.WriteLine("");
            }
            Console.WriteLine("Quel lien voulez-vous ouvrir ?");
            var response = Console.ReadLine();

            int indexToOpen = 0;
            indexToOpen = int.Parse(response);
            UtilsTools.OpenBrowser(allLinks[indexToOpen].Url);
        }

        public static void CreateLinkScreen()
        {
            Console.WriteLine("Nom du lien :");
            string nomLien = Console.ReadLine();

            Console.WriteLine("Description du lien :");
            string descriptionLien = Console.ReadLine();

            Console.WriteLine("Url du lien :");
            string urlLien = Console.ReadLine();

            //Objet à créer dans mon JSON
            var monLien = new LinkModel(Guid.NewGuid(), nomLien, urlLien, descriptionLien);

            CreateLink(monLien);


            Console.WriteLine("");
            Console.WriteLine("Le lien a bien été créé.");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static void CreateLink(LinkModel model)
        {
            //Je récupère tous mes liens
            var allLinks = GetAllLinks();

            //J'ajoute le nouveau lien à ma liste
            allLinks.Add(model);

            //allLinks -> JSON
            string updatedJson = JsonSerializer.Serialize(allLinks);

            //JSON -> Ecraser le fichier
            File.WriteAllText(pathLinksJson, updatedJson);
        }
    }
}
