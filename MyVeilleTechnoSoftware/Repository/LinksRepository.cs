using MyVeilleTechnoSoftware.Models;
using System.Text.Json;
using MyVeilleTechnoSoftware.Utils;

namespace MyVeilleTechnoSoftware.Repository
{
    public static class LinksRepository
    {
        public static List<LinkModel> GetAllLinks()
        {
            List<LinkModel> allLinks = new List<LinkModel>();

            //Lire le fichier JSON, et le transformer en objet
            using (StreamReader r = new StreamReader("Data/links.json"))
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
    }
}
