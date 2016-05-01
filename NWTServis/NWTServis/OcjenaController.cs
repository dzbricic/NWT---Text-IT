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
    public class OcjenaController : ApiController
    {
        private TextITDbContext db = new TextITDbContext();

        // GET api/Ocjena
        public IQueryable<Ocjena> GetOcjenas()
        {
            return db.Ocjenas;
        }

        // GET api/Ocjena/5
        [ResponseType(typeof(Ocjena))]
        public IHttpActionResult GetOcjena(int id)
        {
            Ocjena ocjena = db.Ocjenas.Find(id);
            if (ocjena == null)
            {
                return NotFound();
            }

            return Ok(ocjena);
        }

        // PUT api/Ocjena/5
        public IHttpActionResult PutOcjena(int id, Ocjena ocjena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ocjena.ocjenaID)
            {
                return BadRequest();
            }

            db.Entry(ocjena).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcjenaExists(id))
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

        // POST api/Ocjena
        [ResponseType(typeof(Ocjena))]
        public IHttpActionResult PostOcjena(Ocjena ocjena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ocjenas.Add(ocjena);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ocjena.ocjenaID }, ocjena);
        }

        // DELETE api/Ocjena/5
        [ResponseType(typeof(Ocjena))]
        public IHttpActionResult DeleteOcjena(int id)
        {
            Ocjena ocjena = db.Ocjenas.Find(id);
            if (ocjena == null)
            {
                return NotFound();
            }

            db.Ocjenas.Remove(ocjena);
            db.SaveChanges();

            return Ok(ocjena);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OcjenaExists(int id)
        {
            return db.Ocjenas.Count(e => e.ocjenaID == id) > 0;
        }
    }
}