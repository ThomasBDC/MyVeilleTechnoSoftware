// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System;
using MyVeilleTechnoSoftware.Models;
using MyVeilleTechnoSoftware.Utils;
using MyVeilleTechnoSoftware.Repository;
using System.Transactions;
using MyVeilleTechnoSoftware.Hmi;

bool userContinue = true;
while (userContinue)
{
    App();
}

Console.WriteLine("");
Console.WriteLine("Bye bye !");


//Permettre à l'utilisateur de rechecher sur le titre et sur la description

void App()
{
    //Menu de l'application 
    Console.Clear();
    Console.WriteLine("Bienvenue dans votre application de gestion de veille technologique !");
    Console.WriteLine("");
    Console.WriteLine("Que voulez-vous faire ? ");
    Console.WriteLine("1 - Consulter les liens");
    Console.WriteLine("2 - Créer un lien");
    Console.WriteLine("3 - Consulter les séries");
    Console.WriteLine("4 - Créer une série");
	Console.WriteLine("300 - Quitter l'application");

    var response = Console.ReadLine();

    switch (response)
    {
        case "1":
            //Récupérer tous les liens du fichier JSON
            List<LinkModel> allLinks = LinksRepository.GetAllLinks();

            Console.WriteLine("Votre recherche ...");
            string responseSearch = Console.ReadLine();


            var linksFiltered = LinksRepository.SearchLinks(allLinks, responseSearch);

            bool userStayInResearchMode = true;
            //Je reste en recherche tant que l'utilisateur ne veut pas retourner à l'accueil
            while (userStayInResearchMode)
            {
                Console.Clear();
                //Proposer à l'utilisateur de choisir un lien 
                var selectLink = LinksHMI.ProposeToUserToSelectLink(linksFiltered);
                if (selectLink == null)
                {
                    userStayInResearchMode = false;
                }
                else
                { 
                  userStayInResearchMode = LinksHMI.LinkDetailMenu(selectLink);
                }
            }
            

            break;
        case "2":
            //Permettre à l'utilisateur de créer un lien (et de l'ajouter au fichier JSON)
            LinksHMI.CreateLinkScreen();
            break;
        case "3":
            //Afficher les séries du document JSON
            var allSeries = SeriesRepository.GetAllSeries();

			var selectSerie = SeriesHMI.ProposeToUserToSelectSerie(allSeries);
            //Récupérer les liens liés à cette série, et les afficher
            if (selectSerie != null)
            {
                var linksSeries = LinksRepository.GetAllLinks().Where(link => link.IdSerie == selectSerie.Id).ToList();
			    var selectLinkFromSeries = LinksHMI.ProposeToUserToSelectLink(linksSeries);
			}

			break;
		case "4":
			//Permettre à l'utilisateur de créer un lien (et de l'ajouter au fichier JSON)
			SeriesHMI.CreateSerieScreen();
			break;
		case "300":
            userContinue = false;
            break;
    }
}
