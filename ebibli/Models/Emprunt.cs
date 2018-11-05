using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ebibli.Models
{
    [Table("Emprunt")]
    public class Emprunt
    {
        [Key]
        public int IdEmprunt { get; set; }
        [Required]
        public int IdLivre { get; set; }
        [Required]
        public int IdClient { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
    }
}