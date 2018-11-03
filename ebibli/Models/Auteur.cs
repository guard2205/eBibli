using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ebibli.Models
{
        [Table("Auteur")]
        public class Auteur
        {
            public int Id { get; set; }
            [Required]
            public string Nom { get; set; }
            [Required]
            public string Prenom { get; set; }
        }
}