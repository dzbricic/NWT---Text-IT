using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TextIT.Models
{
    [Table(name: "Komentari")]
    public class Komentar
    {
        public int komentarID { get; set; }
        public string sadrzaj { get; set; }
        public DateTime datumObjave { get; set; }
        public int korisnikID { get; set; }
        public virtual Korisnik korisnik { get; set; }
        
    }
}