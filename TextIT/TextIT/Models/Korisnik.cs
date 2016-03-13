using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TextIT.Models
{
    [Table(name: "Korisnici")]
    public class Korisnik
    {

        public int korisnikID { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string korisnickoIme { get; set; }
        public string sifra { get; set; }
        public string email { get; set; }
        public string tipKorisnika { get; set; }

        public List<Tekst> tekstovi { get; set; }
        public List<Komentar> komentari { get; set; }
        public List<Grupa> grupe { get; set; }
       

    }
}