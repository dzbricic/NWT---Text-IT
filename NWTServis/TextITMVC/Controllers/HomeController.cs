using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using ServisTextIT.Models;
using System.Net.Mail;


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
        public ActionResult Login()
        {
              return View();
        }
        public ActionResult ResetPass()
        {
            return View();
        }

        //funkcija za slanje maila
        private void SendRegistrationMail(string mailTo)
        {
            string link = "http://localhost:36729/Registration/confirmregistration";

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("sgrosic1@gmail.com");
            msg.To.Add(new MailAddress(mailTo));
            msg.Body = "Potvrdite Vašu novu lozinku, kliknite<a href=" + link + ">ovdje</a>!";
            msg.Subject = "Potvrda lozinke";
            msg.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            smtpClient.Credentials = new System.Net.NetworkCredential("sgrosic1", "88aida19");
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);
        }



    }
}