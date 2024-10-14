using MyVeilleTechnoSoftware.Models;
using MyVeilleTechnoSoftware.Repository;
using MyVeilleTechnoSoftware.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVeilleTechnoSoftware.Hmi
{
    internal static class LinksHMI
    {
        public static LinkModel ProposeToUserToSelectLink(List<LinkModel> allLinks)
        {
            foreach (var link in allLinks)
            {
                Console.WriteLine(allLinks.IndexOf(link) + " : " + link.Title);
                Console.WriteLine("");
            }
            Console.WriteLine("Quel lien voulez-vous sélectionner ? tapez 'q' pour quitter");
            var response = Console.ReadLine();

            if (string.Equals(response, "q", StringComparison.CurrentCultureIgnoreCase))
            {
                return null;
            }
            else
            {
                int indexToOpen = 0;
                indexToOpen = int.Parse(response);
                var selectLink = allLinks[indexToOpen];

                return selectLink;
            }
        }

        public static void OpenLink(LinkModel link)
        {
            UtilsTools.OpenBrowser(link.Url);
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

            LinksRepository.CreateLink(monLien);


            Console.WriteLine("");
            Console.WriteLine("Le lien a bien été créé.");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        
        public static void ShowLinkSelected(LinkModel selectedLink)
        {
            Console.Clear();
            Console.WriteLine("Lien sélectionné : " + selectedLink.Title);
            Console.WriteLine("");

            Console.WriteLine("Description : " + selectedLink.Description);
            Console.WriteLine("");

            Console.WriteLine("Url : " + selectedLink.Url);
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static bool LinkDetailMenu(LinkModel selectedLink)
        {
            bool wantToGoBackToSearch = false;

            ShowLinkSelected(selectedLink);

            Console.WriteLine("Que voulez-vous faire ? ");
            Console.WriteLine("1 - Modifier le lien");
            Console.WriteLine("2 - Supprimer le lien");
            Console.WriteLine("3 - Ouvrir le lien");
            Console.WriteLine("4 - Ajouter à une série");
            Console.WriteLine("300 - Retour");
            var responseSelectLink = Console.ReadLine();

            switch (responseSelectLink)
            {
                case "1":
                    break;
                case "2":
                    LinksRepository.DeleteLink(selectedLink);


                    Console.WriteLine("");
                    Console.WriteLine("Le lien a bien été suprimé.");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    break;
                case "3":
                    LinksHMI.OpenLink(selectedLink);
                    wantToGoBackToSearch = true;
                    break;
                case "4":
                    //Ajouter le lien à une série
                    var selectSerie = SeriesHMI.ProposeToUserToSelectSerie(SeriesRepository.GetAllSeries());
                    selectedLink.IdSerie = selectSerie.Id;

                    //MàJ du lien (pas propre, mais ça fait le boulot)
                    LinksRepository.DeleteLink(selectedLink);
                    LinksRepository.CreateLink(selectedLink);
                    break;
                case "300":
                    //Essayer de réafficher les résultats de la recherche
                    wantToGoBackToSearch = true;
                    break;
                default:
                    Console.WriteLine("Pas compris, retour à la page d'accueil");
                    break;
            }
            return wantToGoBackToSearch;
        }

    }
}
