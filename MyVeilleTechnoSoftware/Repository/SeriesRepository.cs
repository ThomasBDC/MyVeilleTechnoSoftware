using MyVeilleTechnoSoftware.Models;
using System.Text.Json;
using MyVeilleTechnoSoftware.Utils;
using System.Text.Json.Nodes;
using System.Xml;

namespace MyVeilleTechnoSoftware.Repository
{
    public static class SeriesRepository
    {
        private static string pathSeriesJson = "C:\\Users\\Thomas BDC\\source\\repos\\MyVeilleTechnoSoftware\\MyVeilleTechnoSoftware\\Data\\series.json";
        public static List<SerieModel> GetAllSeries()
        {
            List<SerieModel> allSeries = new List<SerieModel>();

            //Lire le fichier JSON, et le transformer en objet
            using (StreamReader r = new StreamReader(pathSeriesJson))
            {
                string json = r.ReadToEnd();
                allSeries = JsonSerializer.Deserialize<List<SerieModel>>(json);
            }

            return allSeries;
        }

        //public static List<LinkModel> SearchLinks(List<LinkModel> maListe, string recherche)
        //{
        //    var maRequete = from link in maListe
        //                    where link.Title.Contains(recherche, StringComparison.CurrentCultureIgnoreCase)
        //                    || link.Description.Contains(recherche, StringComparison.CurrentCultureIgnoreCase)
        //                    select link;

        //    return maRequete.ToList();
        //}


        //public static LinkModel ProposeToUserToSelectLink(List<LinkModel> allLinks)
        //{
        //    foreach (var link in allLinks)
        //    {
        //        Console.WriteLine(allLinks.IndexOf(link) + " : " + link.Title);
        //        Console.WriteLine("");
        //    }
        //    Console.WriteLine("Quel lien voulez-vous sélectionner ? tapez 'q' pour quitter");
        //    var response = Console.ReadLine();

        //    if (string.Equals(response, "q", StringComparison.CurrentCultureIgnoreCase))
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        int indexToOpen = 0;
        //        indexToOpen = int.Parse(response);
        //        var selectLink = allLinks[indexToOpen];

        //        return selectLink;
        //    }
        //}

        //public static void CreateLinkScreen()
        //{
        //    Console.WriteLine("Nom du lien :");
        //    string nomLien = Console.ReadLine();

        //    Console.WriteLine("Description du lien :");
        //    string descriptionLien = Console.ReadLine();

        //    Console.WriteLine("Url du lien :");
        //    string urlLien = Console.ReadLine();

        //    //Objet à créer dans mon JSON
        //    var monLien = new LinkModel(Guid.NewGuid(), nomLien, urlLien, descriptionLien);

        //    CreateLink(monLien);


        //    Console.WriteLine("");
        //    Console.WriteLine("Le lien a bien été créé.");
        //    Console.WriteLine("");
        //    Console.WriteLine("");
        //}

        //public static void CreateLink(LinkModel model)
        //{
        //    //Je récupère tous mes liens
        //    var allLinks = GetAllLinks();

        //    //J'ajoute le nouveau lien à ma liste
        //    allLinks.Add(model);

        //    //allLinks -> JSON
        //    string updatedJson = JsonSerializer.Serialize(allLinks);

        //    //JSON -> Ecraser le fichier
        //    File.WriteAllText(pathSeriesJson, updatedJson);
        //}


        //public static void DeleteLink(LinkModel model)
        //{
        //    //Je récupère tous mes liens
        //    var allLinks = GetAllLinks();

        //    //Je recherche tous les éléments avec un id différent de mon élément à supprimer
        //    //On fait la même liste, mais avec notre élément en moins
        //    var newListOfAllLinks = allLinks.Where(link => link.Id != model.Id).ToList();

        //    //allLinks -> JSON
        //    string updatedJson = JsonSerializer.Serialize(newListOfAllLinks);

        //    //JSON -> Ecraser le fichier
        //    File.WriteAllText(pathSeriesJson, updatedJson);
        //}
    }
}
