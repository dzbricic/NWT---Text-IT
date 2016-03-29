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
    public class HashTagController : ApiController
    {
        private TextITDbContext db = new TextITDbContext();

        // GET api/HashTag
        public IQueryable<HashTag> Gethashtags()
        {
            return db.hashtags;
        }

        // GET api/HashTag/5
        [ResponseType(typeof(HashTag))]
        public IHttpActionResult GetHashTag(int id)
        {
            HashTag hashtag = db.hashtags.Find(id);
            if (hashtag == null)
            {
                return NotFound();
            }

            return Ok(hashtag);
        }

        // PUT api/HashTag/5
        public IHttpActionResult PutHashTag(int id, HashTag hashtag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hashtag.hashTagID)
            {
                return BadRequest();
            }

            db.Entry(hashtag).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HashTagExists(id))
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

        // POST api/HashTag
        [ResponseType(typeof(HashTag))]
        public IHttpActionResult PostHashTag(HashTag hashtag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.hashtags.Add(hashtag);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hashtag.hashTagID }, hashtag);
        }

        // DELETE api/HashTag/5
        [ResponseType(typeof(HashTag))]
        public IHttpActionResult DeleteHashTag(int id)
        {
            HashTag hashtag = db.hashtags.Find(id);
            if (hashtag == null)
            {
                return NotFound();
            }

            db.hashtags.Remove(hashtag);
            db.SaveChanges();

            return Ok(hashtag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HashTagExists(int id)
        {
            return db.hashtags.Count(e => e.hashTagID == id) > 0;
        }
    }
}