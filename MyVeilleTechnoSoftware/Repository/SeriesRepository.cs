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


		public static SerieModel ProposeToUserToSelectSerie(List<SerieModel> allSeries)
		{
			foreach (var serie in allSeries)
			{
				Console.WriteLine(allSeries.IndexOf(serie) + " : " + serie.Title);
				Console.WriteLine("");
			}
			Console.WriteLine("Quel série voulez-vous sélectionner ? tapez 'q' pour quitter");
			var response = Console.ReadLine();

			if (string.Equals(response, "q", StringComparison.CurrentCultureIgnoreCase))
			{
				return null;
			}
			else
			{
				int indexToOpen = 0;
				indexToOpen = int.Parse(response);
				var selectLink = allSeries[indexToOpen];

				return selectLink;
			}
		}


		public static void CreateSerieScreen()
		{
			Console.WriteLine("Nom de la serie :");
			string nomSerie = Console.ReadLine();

			Console.WriteLine("Description de la serie :");
			string descriptionSerie = Console.ReadLine();

			//Objet à créer dans mon JSON
			var monSerie = new SerieModel(Guid.NewGuid(), nomSerie, descriptionSerie);

			CreateSerie(monSerie);


			Console.WriteLine("");
			Console.WriteLine("La serie a bien été créée.");
			Console.WriteLine("");
			Console.WriteLine("");
		}

		public static void CreateSerie(SerieModel model)
		{
			//Je récupère tous mes series
			var allSeries = GetAllSeries();

			//J'ajoute le nouveau lien à ma liste
			allSeries.Add(model);

			//allLinks -> JSON
			string updatedJson = JsonSerializer.Serialize(allSeries);

			//JSON -> Ecraser le fichier
			File.WriteAllText(pathSeriesJson, updatedJson);
		}


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
