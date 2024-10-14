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

        public static void DeleteSerie(SerieModel model)
        {
            //Je récupère tous mes liens
            var allSeries = GetAllSeries();

            //Je recherche tous les éléments avec un id différent de mon élément à supprimer
            //On fait la même liste, mais avec notre élément en moins
            var newListOfAllSeries = allSeries.Where(serie => serie.Id != model.Id).ToList();

            //allLinks -> JSON
            string updatedJson = JsonSerializer.Serialize(newListOfAllSeries);

            //JSON -> Ecraser le fichier
            File.WriteAllText(pathSeriesJson, updatedJson);
        }
	}
}
