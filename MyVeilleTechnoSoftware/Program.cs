// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System;
using MyVeilleTechnoSoftware.Models;
using MyVeilleTechnoSoftware.Utils;
using MyVeilleTechnoSoftware.Repository;

Console.WriteLine("Bienvenue dans votre application de gestion de veille technologique !");


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
        //Proposer à l'utilisateur de choisir un lien à ouvrir
        LinksRepository.ProposeToUserToOpenLink(allLinks);
        break;
    case "2":
        //Permettre à l'utilisateur de créer un lien (et de l'ajouter au fichier JSON)
        LinksRepository.CreateLinkScreen();
        break;
}


//Permettre à l'utilisateur de rechecher sur le titre et sur la description
