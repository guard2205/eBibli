using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ebibli.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal() { bdd = new BddContext(); }
        public void Dispose() { bdd.Dispose(); }

        // Auteur
        public List<Auteur> ObtientTousLesAuteurs()
        { return bdd.Auteurs.ToList(); }

        public int AjouteurAuteur(string nom, string prenom)
        {
            Auteur AuteurAdd = bdd.Auteurs.Add(new Auteur { Nom = nom, Prenom = prenom });
            bdd.SaveChanges();
            return AuteurAdd.Id;
        }

        public Auteur ObtenirAuteur(int id)
        {
            Auteur auteurTrouve = bdd.Auteurs.FirstOrDefault(auteur => auteur.Id == id);
            return auteurTrouve;
        }

        public void ModifierAuteur(int id, string nom, string prenom)
        {
            Auteur auteurTrouve = bdd.Auteurs.FirstOrDefault(auteur => auteur.Id == id);
            if (auteurTrouve != null)
            {
                auteurTrouve.Nom = nom;
                auteurTrouve.Prenom = prenom;
                bdd.SaveChanges();
            }
        }
        public bool AuteurExiste(string nom)
        {
            Auteur auteurTrouve = bdd.Auteurs.FirstOrDefault(auteur => auteur.Nom == nom);
            if (auteurTrouve != null)
                return true;
            else
                return false;
        }

        //Client 
        public Client ObtenirClient(int id)
        {
            Client ClientTrouve = bdd.Clients.FirstOrDefault(client => client.Id == id);
            return ClientTrouve;
        }
        public Client ObtenirClient(string idStr)
        {
            Client ClientTrouve = bdd.Clients.FirstOrDefault(client => client.Id.ToString() == idStr);
            return ClientTrouve;
        }
        public int AjouterClient(string nom, string email, string motDePasse)
        {
            Client ClientAdd = bdd.Clients.Add(new Client { Nom = nom, Email = email, MotDePasse = motDePasse });
            bdd.SaveChanges();
            return ClientAdd.Id;
        }
        public Client Authentifier(string nom, string motDePasse)
        {
            return bdd.Clients.FirstOrDefault(client => client.Nom == nom && client.MotDePasse == motDePasse);
        }
        public Client AuthentifierEMail(string email, string motDePasse)
        {
            return bdd.Clients.FirstOrDefault(client => client.Email == email && client.MotDePasse == motDePasse);
        }

        //Livre
        public int AjouterLivre(string titre, DateTime dateParution, Auteur auteur)
        {
            Livre LivreAdd = bdd.Livres.Add(new Livre { Titre = titre, DateParution = dateParution, Auteur = auteur });
            bdd.SaveChanges();
            return LivreAdd.Id;
        }
        public Livre ObtenirLivre(int id)
        {
            Livre LivreTrouve = bdd.Livres.FirstOrDefault(livre => livre.Id == id);
            return LivreTrouve;
        }

        //Emprunt 
        public int AjouterEmprunt(int idLivre, int idClient, DateTime dateEmprunt)
        {
            Emprunt EmpruntAdd = bdd.Emprunts.Add(new Emprunt { IdLivre = idLivre, IdClient = idClient, DateEmprunt = dateEmprunt });
            bdd.SaveChanges();
            return EmpruntAdd.Id;
        }
        public Emprunt ObtenirEmprunt(int id) { return bdd.Emprunts.FirstOrDefault(emprunt => emprunt.Id == id); }

        public void ModifierEmprunt(int id, int Idclient, int idLivre, DateTime dateEmprunt, DateTime dateRetour)
        {
            Emprunt EmpruntTrouve = bdd.Emprunts.FirstOrDefault(emprunt => emprunt.Id == id);
            if (EmpruntTrouve != null)
            {
                EmpruntTrouve.IdClient = Idclient;
                EmpruntTrouve.IdLivre = idLivre;
                EmpruntTrouve.DateEmprunt = dateEmprunt;
                EmpruntTrouve.DateRetour = dateRetour;
            }
        }

    }
}