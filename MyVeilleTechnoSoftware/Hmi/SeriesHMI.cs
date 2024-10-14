using MyVeilleTechnoSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVeilleTechnoSoftware.Repository;

namespace MyVeilleTechnoSoftware.Hmi
{
    internal static class SeriesHMI
    {
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

            SeriesRepository.CreateSerie(monSerie);


            Console.WriteLine("");
            Console.WriteLine("La serie a bien été créée.");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
