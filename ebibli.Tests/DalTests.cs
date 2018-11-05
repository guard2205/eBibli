using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using ebibli.Models;
using System.Collections.Generic;

namespace Travail3.Tests
{
    [TestClass]
    public class DalTests
    {
        private Dal dal;
        [TestInitialize]
        public void Init_AvantChaqueTest()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());
            dal = new Dal();
        }
        [TestCleanup]
        public void ApresChaqueTest()
        {
            dal.Dispose();
        }

        [TestMethod]
        public void CreerAuteur_AvecUnNouvelAuteur_ObtientTousLesAuteursRenvoitBienLAuteur() {
            dal.AjouteurAuteur("Bogdanov", "Igor");
            List<Auteur> LAuteur = dal.ObtientTousLesAuteurs();

            Assert.IsNotNull(LAuteur);
            Assert.AreEqual(1, LAuteur.Count);
            Assert.AreEqual("Bogdanov", LAuteur[0].Nom);
            Assert.AreEqual("Igor", LAuteur[0].Prenom);
        }

        [TestMethod]
        public void ModifierAuteur_CreationDUnNouvelAuteurEtChangementNomEtPrenom_LaModificationEstCorrecteApresRechargement() {
            dal.AjouteurAuteur("Bogdanov", "Igor");
            dal.ModifierAuteur(1, "Moax", "Yann");

            List<Auteur> LAuteur = dal.ObtientTousLesAuteurs();
            Assert.IsNotNull(LAuteur);
            Assert.AreEqual(1, LAuteur.Count);
            Assert.AreEqual("Moax", LAuteur[0].Nom);
            Assert.AreEqual("Yann", LAuteur[0].Prenom);
        }

        [TestMethod]
        public void AuteurExiste_AvecCreationDunAuteur_RenvoiQuilExiste() {
            dal.AjouteurAuteur("Moax", "Yann");

            bool existe = dal.AuteurExiste("Moax");

            Assert.IsTrue(existe);
        }

        [TestMethod]
        public void AuteurExiste_AvecAuteurInexistant_RenvoiQuilExiste() {
            bool existe = dal.AuteurExiste("Moax");

            Assert.IsFalse(existe);
        }

        [TestMethod]
        public void ObtenirClient_ClientInexistant_RetourneNull() {
            Client client = dal.ObtenirClient(1);
            Assert.IsNull(client);
        }

        [TestMethod]
        public void ObtenirClient_IdNonNumerique_RetourneNull() {
            Client client = dal.ObtenirClient("abc");
            Assert.IsNull(client);
        }

        [TestMethod]
        public void AjouterClient_NouveauClientEtRecuperation_LeClientEstBienRecupere() {
            dal.AjouterClient("Nissan", "Nissan@gmail.com", "azerty");
            Client client = dal.ObtenirClient(1);

            Assert.IsNotNull(client);
            Assert.AreEqual("Nissan", client.Nom);
            Assert.AreEqual("Nissan@gmail.com", client.Email);
        }

        [TestMethod]
        public void Authentifier_LoginMdpOk_AuthentificationOK() {
            dal.AjouterClient("Nissan", "Nissan@gmail.com", "azerty");
            Client Client = dal.Authentifier("Nissan", "azerty");
            Assert.IsNotNull(Client);
            Assert.AreEqual("Nissan", Client.Nom);
            Assert.AreEqual("Nissan@gmail.com", Client.Email);
        }

        [TestMethod]
        public void Authentifier_LoginOkMdpKo_AuthentificationKO() {
            dal.AjouterClient("Nissan", "Nissan@gmail.com", "azerty");
            Client client = dal.Authentifier("Nissan", "Qwerty");

            Assert.IsNull(client);
        }

        [TestMethod]
        public void Authentifier_LoginKoMdpOk_AuthentificationKO() {
            dal.AjouterClient("Nissan", "Nissan@gmail.com", "azerty");
            Client client = dal.Authentifier("Nichan", "azerty");
            Assert.IsNull(client);
        }

        [TestMethod]
        public void Authentifier_LoginMdpKo_AuthentificationKO() {
            dal.AjouterClient("Nissan", "Nissan@gmail.com", "azerty");
            Client client = dal.Authentifier("Nichan", "qwerty");
            Assert.IsNull(client);
        }

        [TestMethod]
        public void AjouterLivre__NouveauLivreEtRecuperation_LeLivreEstBienRecupere() {

            DateTime dateParution = DateTime.Parse("06/08/2018");
            int idAuteur = dal.AjouteurAuteur("Bogdanov", "Igor");
            Auteur auteurLivre = dal.ObtenirAuteur(idAuteur);
            dal.AjouterLivre("La physique pour les nuls", dateParution, auteurLivre);
            Livre LivreTrouve = dal.ObtenirLivre(1);

            Assert.IsNotNull(auteurLivre);
            Assert.IsNotNull(LivreTrouve);
            Assert.AreEqual("La physique pour les nuls", LivreTrouve.Titre);
            Assert.AreEqual(dateParution, LivreTrouve.DateParution);
            Assert.AreEqual(auteurLivre, LivreTrouve.Auteur);
        }
    }
}
