// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System;
using MyVeilleTechnoSoftware.Models;
using MyVeilleTechnoSoftware.Utils;
using MyVeilleTechnoSoftware.Repository;

Console.WriteLine("Bienvenue dans votre application de gestion de veille technologique !");
bool userContinue = true;
while (userContinue)
{
    App();

    Console.WriteLine("Voulez-vous continuer ? (O/N)");
    string response = Console.ReadLine();
    userContinue = string.Equals(response, "o", StringComparison.CurrentCultureIgnoreCase);
    if (userContinue)
    {
        Console.Clear();
    }
}




//Permettre à l'utilisateur de rechecher sur le titre et sur la description

void App()
{
    //Menu de l'application 
    Console.WriteLine("Que voulez-vous faire ? ");
    Console.WriteLine("1 - Consulter les liens");
    Console.WriteLine("2 - Créer un lien");

    var response = Console.ReadLine();

    switch (response)
    {
        case "1":
            //Récupérer tous les liens du fichier JSON
            List<LinkModel> allLinks = LinksRepository.GetAllLinks();

            Console.WriteLine("Votre recherche ...");
            string responseSearch = Console.ReadLine();

            var linksFiltered = LinksRepository.SearchLinks(allLinks, responseSearch);

            //Proposer à l'utilisateur de choisir un lien 
            var selectLink = LinksRepository.ProposeToUserToSelectLink(linksFiltered);

            Console.Clear();
            Console.WriteLine("Lien sélectionné : "+selectLink.Title);
            Console.WriteLine("");

            Console.WriteLine("Description : " + selectLink.Description);
            Console.WriteLine("");

            Console.WriteLine("Url : " + selectLink.Url);
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
                    LinksRepository.DeleteLink(selectLink);


                    Console.WriteLine("");
                    Console.WriteLine("Le lien a bien été suprimé.");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    break;
                case "3":
                    LinksRepository.OpenLink(selectLink);
                    break;
                case "4":
                    //Essayer de réafficher les résultats de la recherche
                    break;
                default:
                    Console.WriteLine("Pas compris, retour à la page d'accueil");
                    break;
            }

            break;
        case "2":
            //Permettre à l'utilisateur de créer un lien (et de l'ajouter au fichier JSON)
            LinksRepository.CreateLinkScreen();
            break;
    }
}