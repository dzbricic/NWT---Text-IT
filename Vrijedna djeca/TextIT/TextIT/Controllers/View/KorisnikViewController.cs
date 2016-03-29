using TextIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextIT.Models;

namespace TextIT.Controllers
{
    public class KorisnikViewController : Controller 
    {

        TextITDbContext db = new TextITDbContext();
        public PartialViewResult Index()
        {
            return PartialView();
        }
        public PartialViewResult Profil(int id)
        {
            Korisnik k = db.korisnici.Find(id);
            k.korisnikID = Convert.ToInt32(id);
            return PartialView(k);
        }
        public PartialViewResult Izmjena(int id)
        {

            Korisnik k = db.korisnici.Find(id);
            k.korisnikID = Convert.ToInt32(id);
            
            return PartialView(k);
        }
        public PartialViewResult Dodaj()
        {
            return PartialView();
        }

       

	}
}