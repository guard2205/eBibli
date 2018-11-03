using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ebibli.Models
{
    interface IDal : IDisposable
    {
        //Auteur
        List<Auteur> ObtientTousLesAuteurs();
        int AjouteurAuteur(string nom, string prenom);
        Auteur ObtenirAuteur(int id);
        void ModifierAuteur(int id, string nom, string prenom);
        bool AuteurExiste(string nom);

        //Client 
        Client ObtenirClient(int id);
        Client ObtenirClient(string idStr);
        int AjouterClient(string nom, string email, string motDePasse);
        Client Authentifier(string nom, string motDePasse);
        Client AuthentifierEMail(string email, string motDePasse);

        //Livre
        int AjouterLivre(string titre, DateTime dateParution, Auteur auteur);
        Livre ObtenirLivre(int id);

        //Emprunt 
        int AjouterEmprunt(int idLivre, int idClient, DateTime dateEmprunt);
        Emprunt ObtenirEmprunt(int id);
        void ModifierEmprunt(int id, int Idclient, int idLivre, DateTime dateEmprunt, DateTime dateRetour);

    }
}