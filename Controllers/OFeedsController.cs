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
using Bitcoin.Models;

namespace Bitcoin.Controllers
{
    public class OFeedsController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/OFeeds
        public IQueryable<Feed> GetFeeds()
        {
            return db.Feeds;
        }

        // GET: api/OFeeds/5
        [ResponseType(typeof(Feed))]
        public IHttpActionResult GetFeed(int id)
        {
            var feeds = db.Feeds.Where(x => x.ForumId == id).ToList();
            if (feeds == null)
            {
                return NotFound();
            }

            return Ok(feeds);
        }

        // PUT: api/OFeeds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeed(int id, Feed feed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feed.Id)
            {
                return BadRequest();
            }

            db.Entry(feed).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedExists(id))
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

        // POST: api/OFeeds
        [ResponseType(typeof(Feed))]
        public IHttpActionResult PostFeed(Feed feed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Feeds.Add(feed);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = feed.Id }, feed);
        }

        // DELETE: api/OFeeds/5
        [ResponseType(typeof(Feed))]
        public IHttpActionResult DeleteFeed(int id)
        {
            Feed feed = db.Feeds.Find(id);
            if (feed == null)
            {
                return NotFound();
            }

            db.Feeds.Remove(feed);
            db.SaveChanges();

            return Ok(feed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedExists(int id)
        {
            return db.Feeds.Count(e => e.Id == id) > 0;
        }
    }
}