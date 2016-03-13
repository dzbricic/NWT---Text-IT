using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TextIT.Models
{
    [Table(name: "Tekstovi")]
    public class Tekst
    {
        public int tekstID { get; set; }
       
        public string naslov{ get; set; }
        public string sadrzaj { get; set; }
        public string link { get; set; }
        public bool like { get; set; }
        public DateTime datumObjave { get; set; }
        public int korisnikID { get; set; }
        public virtual Korisnik korisnik { get; set; }
        public List<Komentar> komentari { get; set; }
        public List<HashTag> oznake { get; set; }
        public List<Ocjena> ocjene { get; set; }

    }
}