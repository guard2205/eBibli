using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ebibli.Models
{
    [Table("Livre")]
    public class Livre
    {
        [Key]
        public int IdLivre { get; set; }
        [Required]
        public string Titre { get; set; }
        public DateTime DateParution { get; set; }
         public Auteur Auteur { get; set; }
        public int  IDAuteur { get; set; }

    }
}