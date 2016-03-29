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
    public class TekstController : ApiController
    {
        private TextITDbContext db = new TextITDbContext();

        // GET api/Tekst
        public IQueryable<Tekst> Gettekstovi()
        {
            return db.tekstovi;
        }

        // GET api/Tekst/5
        [ResponseType(typeof(Tekst))]
        public IHttpActionResult GetTekst(int id)
        {
            Tekst tekst = db.tekstovi.Find(id);
            if (tekst == null)
            {
                return NotFound();
            }

            return Ok(tekst);
        }

        // PUT api/Tekst/5
        public IHttpActionResult PutTekst(int id, Tekst tekst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tekst.tekstID)
            {
                return BadRequest();
            }

            db.Entry(tekst).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TekstExists(id))
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

        // POST api/Tekst
        [ResponseType(typeof(Tekst))]
        public IHttpActionResult PostTekst(Tekst tekst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            tekst.datumObjave = DateTime.Now;
            db.tekstovi.Add(tekst);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tekst.tekstID }, tekst);
        }

        // DELETE api/Tekst/5
        [ResponseType(typeof(Tekst))]
        public IHttpActionResult DeleteTekst(int id)
        {
            Tekst tekst = db.tekstovi.Find(id);
            if (tekst == null)
            {
                return NotFound();
            }

            db.tekstovi.Remove(tekst);
            db.SaveChanges();

            return Ok(tekst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TekstExists(int id)
        {
            return db.tekstovi.Count(e => e.tekstID == id) > 0;
        }
    }
}