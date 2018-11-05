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
            return AuteurAdd.IdAuteur;
        }

        public Auteur ObtenirAuteur(int id)
        {
            Auteur auteurTrouve = bdd.Auteurs.FirstOrDefault(auteur => auteur.IdAuteur == id);
            return auteurTrouve;
        }

        public void ModifierAuteur(int id, string nom, string prenom)
        {
            Auteur auteurTrouve = bdd.Auteurs.FirstOrDefault(auteur => auteur.IdAuteur == id);
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
        public bool AuteurExiste(int idAuteur)
        {
            Auteur auteurTrouve = bdd.Auteurs.FirstOrDefault(auteur => auteur.IdAuteur == idAuteur);
            if (auteurTrouve != null)
                return true;
            else
                return false;
        }

        //Client 
        public Client ObtenirClient(int id)
        {
            Client ClientTrouve = bdd.Clients.FirstOrDefault(client => client.IdClient == id);
            return ClientTrouve;
        }
        public Client ObtenirClient(string idStr)
        {
            Client ClientTrouve = bdd.Clients.FirstOrDefault(client => client.IdClient.ToString() == idStr);
            return ClientTrouve;
        }
        public int AjouterClient(string nom, string email, string motDePasse)
        {
            Client ClientAdd = bdd.Clients.Add(new Client { Nom = nom, Email = email, MotDePasse = motDePasse });
            bdd.SaveChanges();
            return ClientAdd.IdClient;
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
            return LivreAdd.IdLivre;
        }
        public Livre ObtenirLivre(int idlivre)
        {
            Livre LivreTrouve = bdd.Livres.FirstOrDefault(livre => livre.IdLivre == idlivre);
            return LivreTrouve;
        }

        public List<Livre> ObtenirTousLesLivres()
        {
            return bdd.Livres.ToList();
        }
        public List<Livre> ObtenirLivresAuteur(int IdAuteur)
        {
            return bdd.Livres.Where(livre => livre.IdLivre == IdAuteur).ToList();

        }
        public bool LivreExiste(int idLivre)
        {
            Livre LivreTrouve = bdd.Livres.FirstOrDefault(livre => livre.IdLivre == idLivre);
            if (LivreTrouve != null)
                return true;
            else
                return false;

        }

        //Emprunt 
        public int AjouterEmprunt(int idLivre, int idClient, DateTime dateEmprunt)
        {
            Emprunt EmpruntAdd = bdd.Emprunts.Add(new Emprunt { IdLivre = idLivre, IdClient = idClient, DateEmprunt = dateEmprunt });
            bdd.SaveChanges();
            return EmpruntAdd.IdEmprunt;
        }
        public Emprunt ObtenirEmprunt(int id) { return bdd.Emprunts.FirstOrDefault(emprunt => emprunt.IdEmprunt == id); }

        public void ModifierEmprunt(int id, int Idclient, int idLivre, DateTime dateEmprunt, DateTime dateRetour)
        {
            Emprunt EmpruntTrouve = bdd.Emprunts.FirstOrDefault(emprunt => emprunt.IdEmprunt == id);
            if (EmpruntTrouve != null)
            {
                EmpruntTrouve.IdClient = Idclient;
                EmpruntTrouve.IdLivre = idLivre;
                EmpruntTrouve.DateEmprunt = dateEmprunt;
                EmpruntTrouve.DateRetour = dateRetour;
            }
        }

        public void RetournerEmprunt(int idEmprunt)
        {
            Emprunt empruntTrouve = bdd.Emprunts.FirstOrDefault(emprunt => emprunt.IdEmprunt == idEmprunt);
            if ( empruntTrouve != null)
            {
                empruntTrouve.DateRetour = DateTime.Now;
                bdd.SaveChanges();
            }

        }
        public List<Emprunt> ObtenirEmpruntsLivre(int idlivre)
        {
            return bdd.Emprunts.Where(emprunt => emprunt.IdLivre == idlivre).ToList();
        }
        public List<Emprunt> ObtenirEmpruntsClient(int idClient)
        {
            return bdd.Emprunts.Where(emprunt => emprunt.IdClient == idClient).ToList();
        }


    }
}