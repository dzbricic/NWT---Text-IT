using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TextIT.Models;

namespace TextIT.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Korisnik u)
        {
            if (ModelState.IsValid) 
            {
                using (TextITDbContext dc = new TextITDbContext())
                {
                    var v = dc.korisnici.Where(a => a.ime.Equals(u.ime) && a.sifra.Equals(u.sifra)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["ID"] = v.korisnikID.ToString();
                        Session["LogedUserFullname"] = v.ime.ToString();
                        Session["TipKorisnika"] = v.tipKorisnika.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(u);
        }


        public ActionResult Index()
        {
                return View();
            
        }        
    }
}
