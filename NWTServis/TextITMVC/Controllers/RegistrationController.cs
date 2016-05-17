using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using reCAPTCHA;
using reCAPTCHA.MVC;
using System.Net;
using ServisTextIT.Models;
using System.Net.Mail;
using ServisTextIT.Models; 



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

        //funkcija za slanje maila
        private void SendRegistrationMail(string mailTo)
        {
            string link = "http://localhost:36729/Registration/confirmregistration"; 

            MailMessage msg = new MailMessage();
             
            msg.From = new MailAddress("sgrosic1@gmail.com");
            msg.To.Add(new MailAddress(mailTo)); 
            msg.Body = "Dobrodošli na našu stranicu! Kliknite<a href="+ link +">ovdje</a> da potvrdite Vašu registraciju!";        
            msg.Subject = "Potvrda registracije";
            msg.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            smtpClient.Credentials = new System.Net.NetworkCredential("sgrosic1", "88aida19");
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);
        }

        //funkcija za potvrdu mail-a
        public async Task<ActionResult> confirmregistration()
        {
            int userId = Convert.ToInt32(Session["id"].ToString());
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + userId);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var korisnik = JsonConvert.DeserializeObject<Korisnik>(responseData);
                if (korisnik != null)
                {
                    korisnik.potvrda = true;
                    HttpResponseMessage responseMessage1 = await client.PutAsJsonAsync(url + "/" + userId, korisnik);
                    if (responseMessage1.IsSuccessStatusCode)
                    {
                        return View("~/Views/Registration/Uspjesno.cshtml");
                    }
                   
                   
                }
                else return View("~/Views/Registration/FailRegistration.cshtml");
              
            }
            return View("Error");
                 /*var korisnik db.Korisnik.Find(userId);
            if(korisnik != null) {
                korisnik.Potvrđen = true;
	            db.SaveChanges();
                return View(); 
            }else return View(); //neki view sa porukom da korisnik ne postoji*/
}


        

        [HttpPost]
        public async Task<ActionResult> RegisterUser(Korisnik Emp)
        {

           // HttpResponseMessage responseMessage = await client.PostAsJsonAsync<Korisnik>(url, Emp);
        
           
               //dodan za recaptcha
                var response = Request["g-recaptcha-response"];
                //secret that was generated in key value pair
                const string secret = "6LcRYx8TAAAAAGlbk0C8WvSBIFjpzZ6j1pTIQCuC";

                var client1 = new WebClient();
                var reply =
                    client1.DownloadString(
                        string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

                var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

                //when response is false check for the error message
                if (!captchaResponse.Success)
                {
                    if (captchaResponse.ErrorCodes.Count <= 0) return View();

                    var error = captchaResponse.ErrorCodes[0].ToLower();
                    switch (error)
                    {
                        case ("missing-input-secret"):
                            ViewBag.Message = "The secret parameter is missing.";
                            TempData["notice"] = "The secret parameter is missing.";
                            return RedirectToAction("RegisterUser", "Registration");
                           // break;
                        case ("invalid-input-secret"):
                            ViewBag.Message = "The secret parameter is invalid or malformed.";
                            TempData["notice"] = "The secret parameter is invalid or malformed.";
                            return RedirectToAction("RegisterUser", "Registration");
                           // break;

                        case ("missing-input-response"):
                            ViewBag.Message = "The response parameter is missing.";
                            TempData["notice"] = "The response parameter is missing.";
                            return RedirectToAction("RegisterUser", "Registration");
                           // break;
                        case ("invalid-input-response"):
                            ViewBag.Message = "The response parameter is invalid or malformed.";
                            TempData["notice"] = "The secret parameter is invalid or malformed.";
                            return RedirectToAction("RegisterUser", "Registration");
                           // break;

                        default:
                            ViewBag.Message = "Error occured. Please try again";
                            TempData["notice"] = "Error occured. Please try again";
                            return RedirectToAction("RegisterUser", "Registration");
                            //break;
                    }
                }
                else
                {
                    ViewBag.Message = "Valid";
                   
                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync<Korisnik>(url, Emp);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                       // TempData["alertMessage"] = "USPJESNO";
                        //ako su validni svi podaci o korisniku, potrebno je pozvati metodu za slanje maila
                        Korisnik k = await responseMessage.Content.ReadAsAsync<Korisnik>();
                        
                        string mail = Emp.email.ToString();
                        //int id = k.korisnikID;
                        Session["id"] = k.korisnikID;
                        SendRegistrationMail(mail);
                    }
                    else
                        return RedirectToAction("Error");

                    return View("~/Views/Registration/Link.cshtml");
                }

                //kraj


            // if (responseMessage.IsSuccessStatusCode)
            // {
                //return RedirectToAction("Index", "Home");
            //}
            //return RedirectToAction("Error");
        }


        // GET: /Registration/
        /*public ActionResult Index()
        {
            return View();
        }*/


      /*  [HttpPost]
        public ActionResult ValidateCaptcha()
        {
            var response = Request["g-recaptcha-response"];
            //secret that was generated in key value pair
            const string secret = "6LcRYx8TAAAAAGlbk0C8WvSBIFjpzZ6j1pTIQCuC";

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //when response is false check for the error message
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes.Count <= 0) return View();

                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case ("missing-input-secret"):
                        ViewBag.Message = "The secret parameter is missing.";
                        break;
                    case ("invalid-input-secret"):
                        ViewBag.Message = "The secret parameter is invalid or malformed.";
                        break;

                    case ("missing-input-response"):
                        ViewBag.Message = "The response parameter is missing.";
                        break;
                    case ("invalid-input-response"):
                        ViewBag.Message = "The response parameter is invalid or malformed.";
                        break;

                    default:
                        ViewBag.Message = "Error occured. Please try again";
                        break;
                }
            }
            else
            {
                ViewBag.Message = "Valid";
            }

            return View();
        }*/
	}
}