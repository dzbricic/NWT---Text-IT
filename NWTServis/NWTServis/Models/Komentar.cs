﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServisTextIT.Models
{
    [Table(name: "Komentari")]
    public class Komentar
    {
        public int komentarID { get; set; }
        [DisplayName("Komentar:")]
        [Required(ErrorMessage = "Niste unijeli komentar !")]
        public string sadrzaj { get; set; }
        public DateTime datumObjave { get; set; }
        public int tekstID { get; set; }
        [JsonIgnore]
        public virtual Tekst tekst { get; set; }
        public int korisnikOstavioID { get; set; }
        [JsonIgnore]
        public virtual Korisnik korisnikOstavio { get; set; }

    }
}