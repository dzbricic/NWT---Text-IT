using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace TextITMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET:/Home/
        public ActionResult Korisnici()
        {
            List<Korisnik> l = new List<Korisnik>();
            HttpClient client = new HttpClient();
            client.BaseAddress =new Uri ("http://localhost:3106/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/korisnik").Result;
            if (response.IsSuccessStatusCode)
            {

                l = response.Content.ReadAsAsync<List<Korisnik>>().Result;
            }
            return View(l);
        }

    }
}