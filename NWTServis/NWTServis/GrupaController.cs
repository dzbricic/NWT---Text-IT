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
    public class GrupaController : ApiController
    {
        private TextITDbContext db = new TextITDbContext();

        // GET api/Grupa
        public IQueryable<Grupa> Getgrupe()
        {
            return db.grupe;
        }

        // GET api/Grupa/5
        [ResponseType(typeof(Grupa))]
        public IHttpActionResult GetGrupa(int id)
        {
            Grupa grupa = db.grupe.Find(id);
            if (grupa == null)
            {
                return NotFound();
            }

            return Ok(grupa);
        }

        // PUT api/Grupa/5
        public IHttpActionResult PutGrupa(int id, Grupa grupa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupa.grupaID)
            {
                return BadRequest();
            }

            db.Entry(grupa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupaExists(id))
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

        // POST api/Grupa
        [ResponseType(typeof(Grupa))]
        public IHttpActionResult PostGrupa(Grupa grupa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.grupe.Add(grupa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = grupa.grupaID }, grupa);
        }

        // DELETE api/Grupa/5
        [ResponseType(typeof(Grupa))]
        public IHttpActionResult DeleteGrupa(int id)
        {
            Grupa grupa = db.grupe.Find(id);
            if (grupa == null)
            {
                return NotFound();
            }

            db.grupe.Remove(grupa);
            db.SaveChanges();

            return Ok(grupa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GrupaExists(int id)
        {
            return db.grupe.Count(e => e.grupaID == id) > 0;
        }
    }
}