using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ebibli.Models
{
    [Table("Client")]
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string MotDePasse { get; set; }
    }
}