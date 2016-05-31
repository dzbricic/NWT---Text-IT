using Newtonsoft.Json;
using ServisTextIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TextITMVC.Models;

namespace TextITMVC.Controllers
{
    public class TekstController : Controller
    {



        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:3106/api/tekst";

        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public TekstController()
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

                var Employees = JsonConvert.DeserializeObject<List<Tekst>>(responseData);

                return View(Employees);
            }
            return View("Error");
        }

        public ActionResult Create()
        {
            return View(new Tekst());
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(Tekst Emp)
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

                var Employee = JsonConvert.DeserializeObject<Tekst>(responseData);

                return View(Employee);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Tekst Emp)
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

                var Employee = JsonConvert.DeserializeObject<Tekst>(responseData);

                return View(Employee);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Tekst Emp)
        {

            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


         //akcija za dijagram - broj tekstova po danima
        public async Task<ActionResult> KorisnikBrojTekstova()
        {
            List<MojaLista> t = new List<MojaLista>();
            HttpResponseMessage responseMessage = await client.GetAsync(url); // pokupi sve tekstove
            string url1 = "http://textit.azurewebsites.net/api/korisnik";
            HttpResponseMessage responseMessage1 = await client.GetAsync(url1); // pokupi sve korisnike
            if (responseMessage.IsSuccessStatusCode && responseMessage1.IsSuccessStatusCode)
            {
                //sve tekstove smjesti u listu te
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Tekstovi = JsonConvert.DeserializeObject<List<Tekst>>(responseData);
                List<Tekst> te = await responseMessage.Content.ReadAsAsync<List<Tekst>>();

                // sve korisnike smjesti u listu ko
                var responseData1 = responseMessage1.Content.ReadAsStringAsync().Result;
                var Korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(responseData1);
                List<Korisnik> ko = await responseMessage1.Content.ReadAsAsync<List<Korisnik>>();

                //kreiramo MojaLista - sastoji se iz korisnika i brojaca njegovih tekstova
                
                for (int i = 0; i < ko.Count; i++)
                {
                    int idKo = ko[i].korisnikID;
                    int brojac = 0;
                    foreach (Tekst m in te)
                    {
                        if (m.korisnikID == idKo)
                        {
                            brojac++;
                        }
                    }
                    MojaLista var = new MojaLista(ko[i], brojac);
                    t.Add(var);
                }

            }

            List<String> idList = new List<String>();
            List<int> brojacList = new List<int>();
            foreach(MojaLista l in t)
            {
                idList.Add(l.K.korisnickoIme);
                brojacList.Add(l.Brojac);
            }
           
            IEnumerable<String> resultid = idList.ToList();
            IEnumerable<int> resulttekst = brojacList.ToList();
            
            var key = new Chart(width: 600, height: 400)
            
            .AddTitle("Broj tekstova po korisniku")
            .AddSeries(
                chartType: "bar",
               // legend: "Rainfall",
                name: "Sabinaaa",
                xValue: resultid, xField: "KORISNIK",
                yValues: resulttekst, yFields: "TEKST")
               
            .Write();               
           

            return null;
        }

        public ActionResult Dijagram()
        {
            return View();
        }

        //akcija za dijagram - broj korisnika, broj tekstova, broj komentara

        public async Task<ActionResult> PitaDijagram()
        {
           
            HttpResponseMessage responseMessage = await client.GetAsync(url); // pokupi sve tekstove
            string url1 = "http://textit.azurewebsites.net/api/korisnik";
            HttpResponseMessage responseMessage1 = await client.GetAsync(url1); // pokupi sve korisnike
            string url2 = "http://localhost:3106/api/komentar";
            HttpResponseMessage responseMessage2 = await client.GetAsync(url2);
            int brojtekstova = 0;
            int brojkorisnika = 0;
            int brojkomentara = 0;
            List<String> ln = new List<String>();
            List<int> br = new List<int>();

            if (responseMessage.IsSuccessStatusCode && responseMessage1.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                //sve tekstove smjesti u listu te
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Tekstovi = JsonConvert.DeserializeObject<List<Tekst>>(responseData);
                List<Tekst> te = await responseMessage.Content.ReadAsAsync<List<Tekst>>();

                // sve korisnike smjesti u listu ko
                var responseData1 = responseMessage1.Content.ReadAsStringAsync().Result;
                var Korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(responseData1);
                List<Korisnik> ko = await responseMessage1.Content.ReadAsAsync<List<Korisnik>>();

                // sve komentare smjesti u listu comm
                var responseData2 = responseMessage2.Content.ReadAsStringAsync().Result;
                var Komentari = JsonConvert.DeserializeObject<List<Komentar>>(responseData2);
                List<Komentar> comm = await responseMessage2.Content.ReadAsAsync<List<Komentar>>();

                brojkomentara = comm.Count;
                brojkorisnika = ko.Count;
                brojtekstova = te.Count;

                ln.Add("Komentari");
                br.Add(brojkomentara);
                ln.Add("Korisnici");
                br.Add(brojkorisnika);
                ln.Add("Tekstovi");
                br.Add(brojtekstova);

            }
            
           
            IEnumerable<String> nazivi = ln.ToList();
            IEnumerable<int> brojke = br.ToList();

            var key = new Chart(width: 600, height: 400)

            .AddTitle("Broj tekstova, komentara i korisnika")
            .AddSeries(
                "Default", 
                chartType: "Pie",
                // legend: "Rainfall",                
                xValue: nazivi, 
                yValues: brojke)

            .Write();


            return null;
        }

        //akcija - dijagram broj komentara po korisniku!
        public async Task<ActionResult> KomentarDijagram()
        {

            string url1 = "http://textit.azurewebsites.net/api/korisnik";
            HttpResponseMessage responseMessage1 = await client.GetAsync(url1); // pokupi sve korisnike
            string url2 = "http://localhost:3106/api/komentar";
            HttpResponseMessage responseMessage2 = await client.GetAsync(url2); // pokupi sve komentare
            List<LaraKlasa> lara = new List<LaraKlasa>();
            List<String> korisnickoIme = new List<String>();
            List<int> brojKomentara = new List<int>();

            if (responseMessage1.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {

                // sve korisnike smjesti u listu ko
                var responseData1 = responseMessage1.Content.ReadAsStringAsync().Result;
                var Korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(responseData1);
                List<Korisnik> ko = await responseMessage1.Content.ReadAsAsync<List<Korisnik>>();

                // sve komentare smjesti u listu comm
                var responseData2 = responseMessage2.Content.ReadAsStringAsync().Result;
                var Komentari = JsonConvert.DeserializeObject<List<Komentar>>(responseData2);
                List<Komentar> comm = await responseMessage2.Content.ReadAsAsync<List<Komentar>>();

                for (int i = 0; i < ko.Count; i++)
                {
                    int koid = ko[i].korisnikID;
                    int brojac = 0;
                    for (int j = 0; j < comm.Count; j++)
                    {
                        if (koid == comm[j].korisnikID)
                        {
                            brojac++;
                        }
                    }
                    LaraKlasa novi = new LaraKlasa(ko[i], brojac);
                    lara.Add(novi);
                }

            }

            foreach (LaraKlasa item in lara)
            {
                korisnickoIme.Add(item.Korisnik.korisnickoIme);
                brojKomentara.Add(item.BrojKom);
            }

            IEnumerable<String> nazivi = korisnickoIme.ToList();
            IEnumerable<int> brojke = brojKomentara.ToList();

            var key = new Chart(width: 600, height: 400)

            .AddTitle("Broj tekstova, komentara i korisnika")
            .AddSeries(
                "Default",
                chartType: "Column",
                // legend: "Rainfall",                
                xValue: nazivi,
                yValues: brojke)

            .Write();


            return null;
        }




        public async Task<ActionResult> PitaDijagramAdminUser()
        {

            HttpResponseMessage responseMessage = await client.GetAsync(url); 
            string url1 = "http://textit.azurewebsites.net/api/korisnik";
            HttpResponseMessage responseMessage1 = await client.GetAsync(url1); // pokupi sve korisnike
            
            int brojadmina = 0;
            int brojusera = 0;
            List<String> ln = new List<String>();
            List<int> br = new List<int>();

            if (responseMessage.IsSuccessStatusCode && responseMessage1.IsSuccessStatusCode)
            {
    
                // sve korisnike smjesti u listu ko
                var responseData1 = responseMessage1.Content.ReadAsStringAsync().Result;
                var Korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(responseData1);
                List<Korisnik> ko = await responseMessage1.Content.ReadAsAsync<List<Korisnik>>();
                foreach (Korisnik kor in ko)
                {
                    if (kor.tipKorisnika=="admin")
                        brojadmina+=1;
                    else
                        brojusera+=1;
                }

                ln.Add("Administratori");
                br.Add(brojadmina);
                ln.Add("Korisnici");
                br.Add(brojusera);

            }


            IEnumerable<String> nazivi = ln.ToList();
            IEnumerable<int> brojke = br.ToList();

            var key = new Chart(width: 600, height: 400)

            .AddTitle("Broj administratora i korisnika")
            .AddSeries(
                "Default",
                chartType: "Pie",
                // legend: "Rainfall",                
                xValue: nazivi,
                yValues: brojke)

            .Write();


            return null;
        }
    }



  }
 