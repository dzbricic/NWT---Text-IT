using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TextITMVC.Models;

namespace TextITMVC
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
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8)]
        [MembershipPassword()]
        public string sifra { get; set; }

        [DisplayName("Email:")]
        [Required(ErrorMessage = "Niste unijeli email !")]
        [DataType(DataType.EmailAddress)]
        [StringLength(128)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email nije validan")]
        public string email { get; set; }

        [DisplayName("Tip korisnika:")]
        [Required(ErrorMessage = "Niste unijeli tip korisnika !")]
        //[DefaultValue("User")]
        public string tipKorisnika { get; set; }
        public List<Tekst> tekst { get; set; }
        public List<Komentar> komentari { get; set; }
        public List<Grupa> grupe { get; set; }

        public Korisnik()
        {
            tipKorisnika = "User";
        }

    }
}