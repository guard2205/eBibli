using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ebibli.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }
        public DbSet<Livre> Livres { get; set; }
    }
}