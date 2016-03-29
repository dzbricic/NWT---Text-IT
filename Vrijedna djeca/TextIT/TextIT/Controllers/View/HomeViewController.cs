using TextIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TextIT.Models;

namespace TextIT.Controllers
{
    public class HomeViewController : Controller
    {
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Korisnik u)
        {

            try
            {
               
                  using (TextIT.Models.TextITDbContext dc = new TextITDbContext())
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
            catch (Exception e )
            {
                
                throw e;
            }
            return View(u);
        }


        public ActionResult Index()
        {
                return View();
            
        }        
    }
}
