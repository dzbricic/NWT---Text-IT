using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServisTextIT.Models
{
    [Table(name: "Tekstovi")]
    public class Tekst
    {
        public int tekstID { get; set; }
        [DisplayName("Naslov:")]
        [Required(ErrorMessage = "Niste unijeli naslov teksta !")]
        public string naslov { get; set; }
        [DisplayName("Sadržaj:")]
        [Required(ErrorMessage = "Niste unijeli sadržaj !")]
        public string sadrzaj { get; set; }
        public string link { get; set; }
        public int like { get; set; }
        public DateTime datumObjave { get; set; }
        public List<HashTag> HashTag { get; set; }
        public List<Komentar> komentari { get; set; }
        public List<Ocjena> ocjene { get; set; }
        public int korisnikID { get; set; }
        public virtual Korisnik korisnik { get; set; }


    }
}