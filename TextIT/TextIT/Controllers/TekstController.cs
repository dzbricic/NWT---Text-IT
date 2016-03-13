using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextIT.Models;

namespace TextIT.Controllers
{
    public class TekstController : Controller
    {
        TextITDbContext dc = new TextITDbContext();
        //
        // GET: /Tekst/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KreirajTekst()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KreirajTekst(Tekst t)
        {
            if (ModelState.IsValid)
            {
                using (TextITDbContext dc = new TextITDbContext())
                {
                    t.datumObjave = DateTime.Now;
                    t.korisnikID = Convert.ToInt32(Session["ID"]);
                    dc.tekstovi.Add(t);
                    dc.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
	}
}