using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using NWTServis.Models;

namespace ServisTextIT.Models
{
    [Authorize]
    [Table(name: "Korisnici")]
    public class Korisnik
    {

        public int korisnikID { get; set; }
        [DisplayName("Ime:")]
        [Required(ErrorMessage = "Niste unijeli ime !")]
        public string ime { get; set; }

        [DisplayName("Prezime:")]
        [Required(ErrorMessage = "Niste unijeli prezime !")]
        public string prezime { get; set; }

        [DisplayName("Korisničko ime:")]
        [Required(ErrorMessage = "Niste unijeli korisničko ime !")]
        public string korisnickoIme { get; set; }

        [DisplayName("Sifra:")]
        [Required(ErrorMessage = "Niste unijeli sifru !")]
      //  [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8)]
     //   [MembershipPassword()]
        public string sifra { get; set; }

        [DisplayName("Email:")]
        [Required(ErrorMessage = "Niste unijeli email !")]
        [DataType(DataType.EmailAddress)]
        [StringLength(128)]
        public string email { get; set; }

        [DisplayName("Tip korisnika:")]
        [Required(ErrorMessage = "Niste unijeli tip korisnika !")]
        public string tipKorisnika { get; set; }


        [DisplayName("Potvrda:")]
        public bool potvrda { get; set; }

        [DisplayName("Banovan:")]
        [DefaultValue(false)]
        public bool banovan { get; set; }
        public string salt { get; set; }


        [JsonIgnore]
        public List<Tekst> tekst { get; set; }
        [JsonIgnore]
        public List<Komentar> komentari { get; set; }
    


    }
}