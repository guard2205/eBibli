using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ebibli
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Affiche l'auteur et tous les livres qu'il a écrit
            routes.MapRoute(
                name: "Afficher_Auteur",
                url: "Afficher/Auteur/{IDauteur}/{*Args}",
                defaults: new { Controller = "Affichage", action = "Auteur", IDauteur = 0, Args = UrlParameter.Optional }
            );

            // Affiche un livre, son auteur, l'emprunteur actuel et la liste des emprunteurs passés
            routes.MapRoute(
                name: "Afficher_Livre",
                url: "Afficher/Livre/{IDlivre}/{*Args}",
                defaults: new { Controller = "Affichage", action = "Livre", IDlivre = 0, Args = UrlParameter.Optional }
            );

            // Affiche la liste des auteurs
            routes.MapRoute(
                name: "Afficher_Auteurs",
                url: "Afficher/Auteurs/{*Args}",
                defaults: new { controller = "Affichage", action = "Auteurs", Args = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Afficher",
                url: "Afficher/{*Args}",
                defaults: new { Controller = "Affichage", action = "Index", Args = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "Default",
                 url: "",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
