using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ServisTextIT.Models;
using NWTServis.Models;
using System.Text;

namespace NWTServis
{
    public class LoginController : ApiController
    {



        private TextITDbContext db = new TextITDbContext();


        [ResponseType(typeof(Korisnik))]
        [HttpPost]
        public IHttpActionResult PostKorisnik(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            }
            if (LoginKorisnik(model.Username, model.Password))
            {
                List<Korisnik> korisnici = db.korisnici.Where(k => k.korisnickoIme == model.Username).ToList();
                Korisnik korisnik = new Korisnik();
                for (int i = 0; i < korisnici.Count(); i++)
                {
                    String salt = korisnici[i].salt;
                    String sifrabaza = korisnici[i].sifra;

                    if (sifrabaza == GenerateSHA256Hash(model.Password, salt))
                    {
                        korisnik = korisnici[i];
                        return Ok(korisnik);
                    }
                }
            }
            return NotFound();
        }


        private bool LoginKorisnik(string korisnickoIme, string sifra)
        {
            return db.korisnici.Count(e => e.korisnickoIme == korisnickoIme) > 0;
        }

        public static String ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);

            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        public String CreateSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }


        public String GenerateSHA256Hash(String input, String salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);
            String str = ByteArrayToHexString(hash);
            return str;
        }


        //// GET api/Login
        //public IQueryable<Korisnik> Getkorisnici()
        //{
        //    return db.korisnici;
        //}

        //// GET api/Login/5
        //[ResponseType(typeof(Korisnik))]
        //public IHttpActionResult GetKorisnik(int id)
        //{
        //    Korisnik korisnik = db.korisnici.Find(id);
        //    if (korisnik == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(korisnik);
        //}

        //// PUT api/Login/5
        //public IHttpActionResult PutKorisnik(int id, Korisnik korisnik)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != korisnik.korisnikID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(korisnik).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!KorisnikExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/Login
        //[ResponseType(typeof(Korisnik))]
        //public IHttpActionResult PostKorisnik(Korisnik korisnik)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.korisnici.Add(korisnik);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = korisnik.korisnikID }, korisnik);
        //}

        //// DELETE api/Login/5
        //[ResponseType(typeof(Korisnik))]
        //public IHttpActionResult DeleteKorisnik(int id)
        //{
        //    Korisnik korisnik = db.korisnici.Find(id);
        //    if (korisnik == null)
        //    {
        //        return NotFound();
        //    }

        //    db.korisnici.Remove(korisnik);
        //    db.SaveChanges();

        //    return Ok(korisnik);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool KorisnikExists(int id)
        //{
        //    return db.korisnici.Count(e => e.korisnikID == id) > 0;
        //}
    }
}