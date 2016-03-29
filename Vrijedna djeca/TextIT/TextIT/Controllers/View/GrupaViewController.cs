using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TextIT.Controllers
{
    public class GrupaViewController : Controller
    {
        //
        // GET: /Grupa/
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public PartialViewResult Dodaj()
        {
            return PartialView();
        }
	}
}