using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TextITMVC.Models
{
    [Table(name: "Grupa")]
    public class Grupa
    {
        public int grupaID { get; set; }
        [DisplayName("Naziv grupe:")]
        [Required(ErrorMessage = "Niste unijeli naziv grupe !")]
        public string nazivGrupe { get; set; }
        public List<Tekst> tekstovi { get; set; }
        public int korisnikID { get; set; }
        public virtual Korisnik korisnik { get; set; }
    }
}