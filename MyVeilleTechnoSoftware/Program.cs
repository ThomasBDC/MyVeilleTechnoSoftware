// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System;
using MyVeilleTechnoSoftware.Models;
using MyVeilleTechnoSoftware.Utils;
using MyVeilleTechnoSoftware.Repository;

Console.WriteLine("Bienvenue dans votre application de gestion de veille technologique !");

//Récupérer tous les liens du fichier JSON
List<LinkModel> allLinks = LinksRepository.GetAllLinks();

//Proposer à l'utilisateur de choisir un lien à ouvrir
LinksRepository.ProposeToUserToOpenLink(allLinks);
