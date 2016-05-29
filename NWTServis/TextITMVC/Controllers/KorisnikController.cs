using Newtonsoft.Json;
using ServisTextIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TextITMVC.Controllers
{
    public class KorisnikController : Controller
    {



        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://textit.azurewebsites.net/api/korisnik";

        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public KorisnikController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: EmployeeInfo
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


        public ActionResult Create()
        {
            return View(new Korisnik());
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(Korisnik Emp)
        {

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, Emp);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employee = JsonConvert.DeserializeObject<Korisnik>(responseData);

                return View(Employee);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Korisnik Emp)
        {

            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, Emp);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employee = JsonConvert.DeserializeObject<Korisnik>(responseData);

                return View(Employee);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Korisnik Emp)
        {

            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public ActionResult MojProfil()
        {
            return View();
        }

        //funkcija za slanje maila za reset pass
        private void SendRegistrationMail(string mailTo)
        {
            string link = "http://localhost:36729/Korisnik/confirmregistration"; // izmijeniti link

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("sgrosic1@gmail.com");
            msg.To.Add(new MailAddress(mailTo));
            msg.Body = "Za izmjenu šifre kliknite na sljedeći <a href=" + link + ">link.</a> ";
            msg.Subject = "Izmjena šifre";
            msg.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            smtpClient.Credentials = new System.Net.NetworkCredential("sgrosic1", "88aida19");
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);
        }

        //akcija za slanje korisnika na novi View kada klikne link za potvrdu izmjene lozinke
        public async Task<ActionResult> confirmregistration()
        {
           
               return View("~/Views/Korisnik/Izmjena.cshtml");         

        }

        //akcija za izmjenu nove lozinke 
        public async Task<ActionResult> IzmijeniLozinku(FormCollection collection)
        {
            int userId = Convert.ToInt32(Session["id"].ToString());
            string nova = collection.Get("sifra").ToString();
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + userId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var korisnik = JsonConvert.DeserializeObject<Korisnik>(responseData);
                if (korisnik != null)
                {
                    korisnik.sifra = nova; 
                    HttpResponseMessage responseMessage1 = await client.PutAsJsonAsync(url + "/" + userId, korisnik);
                    if (responseMessage1.IsSuccessStatusCode)
                    {
                        return View("~/Views/Korisnik/Uspjesno.cshtml");
                    }
                }
                else return View("~/Views/Korisnik/Neuspjesno.cshtml");

            }
            return View("Error");
        }



        public ActionResult Izmjena()
        {
            return View(new Korisnik());
        }

        public ActionResult Reset()
        {
            return View(new Korisnik());
        }

        //akcija za pronalazak korisnika putem mail-a, te pozivanje funkcije za slanje mail-a
        public async Task<ActionResult> ResetAction(FormCollection collection)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                string email = collection.Get("email").ToString(); 
                //var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                List<Korisnik> l = await responseMessage.Content.ReadAsAsync<List<Korisnik>>();
                //var Employees = JsonConvert.DeserializeObject<List<Korisnik>>(responseData); // lista korisnika
                Korisnik m = l.Find(k => k.email.ToString() == email); // pronalazi korisnika s mail-om koji smo mu proslijedili
                Session["id"] = m.korisnikID;
                SendRegistrationMail(email); // šalje mu mail

                return View("~/Views/Korisnik/Provjeri.cshtml");
            }
            return View("Error");

        }
        



    }
}