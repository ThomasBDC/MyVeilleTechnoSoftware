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

        public static List<LinkModel> SearchLinks(List<LinkModel> maListe, string recherche)
        {
            var maRequete = from link in maListe
                            where link.Title.Contains(recherche, StringComparison.CurrentCultureIgnoreCase)
                            || link.Description.Contains(recherche, StringComparison.CurrentCultureIgnoreCase)
                            select link;

            return maRequete.ToList();
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

        public static void DeleteLink(LinkModel model)
        {
            //Je récupère tous mes liens
            var allLinks = GetAllLinks();

            //Je recherche tous les éléments avec un id différent de mon élément à supprimer
            //On fait la même liste, mais avec notre élément en moins
            var newListOfAllLinks = allLinks.Where(link => link.Id != model.Id).ToList();

            //allLinks -> JSON
            string updatedJson = JsonSerializer.Serialize(newListOfAllLinks);

            //JSON -> Ecraser le fichier
            File.WriteAllText(pathLinksJson, updatedJson);
        }
    }
}
