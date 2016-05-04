using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextITMVC.Controllers
{
    public class RegistrationController : Controller
    {
        
         HttpClient client;
         string url = "http://localhost:3106/api/korisnik";

        
        public RegistrationController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employees = JsonConvert.DeserializeObject<List<Korisnik>>(responseData);

                return View(Employees);
            }
            return View("Error");
        }

        public ActionResult RegisterUser()
        {
            return View(new Korisnik());
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(Korisnik Emp)
        {

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync<Korisnik>(url, Emp);
        
           // responseMessage.EnsureSuccessStatusCode();
            //responseMessage.Content.ReadAsAsync<HttpResponseMessage>().Wait();
            if (responseMessage.IsSuccessStatusCode)
            {
                
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Error");
        }


        // GET: /Registration/
        /*public ActionResult Index()
        {
            return View();
        }*/
	}
}