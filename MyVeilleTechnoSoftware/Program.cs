// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System;
using MyVeilleTechnoSoftware.Models;
using MyVeilleTechnoSoftware.Utils;
using MyVeilleTechnoSoftware.Repository;
using System.Transactions;

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
    Console.WriteLine("4 - Quitter l'application");

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
                var selectLink = LinksRepository.ProposeToUserToSelectLink(linksFiltered);
                if (selectLink == null)
                {
                    userStayInResearchMode = false;
                }
                else
                { 
                  userStayInResearchMode = ShowSelectedLinkAndGetIfUserWantToGoBackToResearch(selectLink);
                }
            }
            

            break;
        case "2":
            //Permettre à l'utilisateur de créer un lien (et de l'ajouter au fichier JSON)
            LinksRepository.CreateLinkScreen();
            break;
        case "3":
            //Afficher les séries du document JSON
            var allSeries = SeriesRepository.GetAllSeries();

            foreach (var serie in allSeries)
            {
                Console.WriteLine(serie.Title);
            }
            break;
        case "4":
            userContinue = false;
            break;
    }
}

bool ShowSelectedLinkAndGetIfUserWantToGoBackToResearch(LinkModel selectedLink)
{
    bool wantToGoBackToSearch = false;
    Console.Clear();
    Console.WriteLine("Lien sélectionné : " + selectedLink.Title);
    Console.WriteLine("");

    Console.WriteLine("Description : " + selectedLink.Description);
    Console.WriteLine("");

    Console.WriteLine("Url : " + selectedLink.Url);
    Console.WriteLine("");
    Console.WriteLine("");

    Console.WriteLine("Que voulez-vous faire ? ");
    Console.WriteLine("1 - Modifier le lien");
    Console.WriteLine("2 - Supprimer le lien");
    Console.WriteLine("3 - Ouvrir le lien");
    Console.WriteLine("4 - Retour");
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
            LinksRepository.OpenLink(selectedLink);
            wantToGoBackToSearch = true;
            break;
        case "4":
            //Essayer de réafficher les résultats de la recherche
            wantToGoBackToSearch = true;
            break;
        default:
            Console.WriteLine("Pas compris, retour à la page d'accueil");
            break;
    }
    return wantToGoBackToSearch;
}