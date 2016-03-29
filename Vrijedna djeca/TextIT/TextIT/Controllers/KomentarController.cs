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
using TextIT.Models;

namespace TextIT.Controllers
{
    public class KomentarController : ApiController
    {
        private TextITDbContext db = new TextITDbContext();

        // GET api/Komentar
        public IQueryable<Komentar> Getkomentari()
        {
            return db.komentari;
        }

        // GET api/Komentar/5
        [ResponseType(typeof(Komentar))]
        public IHttpActionResult GetKomentar(int id)
        {
            Komentar komentar = db.komentari.Find(id);
            if (komentar == null)
            {
                return NotFound();
            }

            return Ok(komentar);
        }

        // PUT api/Komentar/5
        public IHttpActionResult PutKomentar(int id, Komentar komentar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != komentar.komentarID)
            {
                return BadRequest();
            }

            db.Entry(komentar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KomentarExists(id))
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

        // POST api/Komentar
        [ResponseType(typeof(Komentar))]
        public IHttpActionResult PostKomentar(Komentar komentar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.komentari.Add(komentar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = komentar.komentarID }, komentar);
        }

        // DELETE api/Komentar/5
        [ResponseType(typeof(Komentar))]
        public IHttpActionResult DeleteKomentar(int id)
        {
            Komentar komentar = db.komentari.Find(id);
            if (komentar == null)
            {
                return NotFound();
            }

            db.komentari.Remove(komentar);
            db.SaveChanges();

            return Ok(komentar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KomentarExists(int id)
        {
            return db.komentari.Count(e => e.komentarID == id) > 0;
        }
    }
}