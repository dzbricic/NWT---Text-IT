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

namespace NWTServis
{
    public class KorisnikController : ApiController
    {
        private TextITDbContext db = new TextITDbContext();

        // GET api/Korisnik
        public IQueryable<Korisnik> Getkorisnici()
        {
            return db.korisnici;
        }

        // GET api/Korisnik/5
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult GetKorisnik(int id)
        {
            Korisnik korisnik = db.korisnici.Find(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return Ok(korisnik);
        }

        // PUT api/Korisnik/5
        public IHttpActionResult PutKorisnik(int id, Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisnik.korisnikID)
            {
                return BadRequest();
            }

            db.Entry(korisnik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Korisnik
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult PostKorisnik(Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.korisnici.Add(korisnik);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = korisnik.korisnikID }, korisnik);
        }

        // DELETE api/Korisnik/5
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult DeleteKorisnik(int id)
        {
            Korisnik korisnik = db.korisnici.Find(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            db.korisnici.Remove(korisnik);
            db.SaveChanges();

            return Ok(korisnik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KorisnikExists(int id)
        {
            return db.korisnici.Count(e => e.korisnikID == id) > 0;
        }
    }
}