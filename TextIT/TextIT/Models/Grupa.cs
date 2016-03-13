using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextIT.Models
{

    
    public class Grupa
    {
        public int grupaID { get; set; }
        public string nazivGrupe { get; set; }
        public List<Tekst> tektovi { get; set; }
        public int korisnikID { get; set; }
        public virtual Korisnik korisnik { get; set; }
    }
}