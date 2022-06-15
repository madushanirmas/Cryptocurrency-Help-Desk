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
    public class BitusersController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/Bitusers
        public IQueryable<Bituser> GetBitusers()
        {
            return db.Bitusers;
        }

        // GET: api/Bitusers
        [ResponseType(typeof(Bituser))]
        public IHttpActionResult GetBituser(string email, string password)
        {
            Bituser bituser = db.Bitusers.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (bituser == null)
            {
                return NotFound();
            }
            
            return Ok(bituser);
        }


        [ResponseType(typeof(Bituser))]
        public IHttpActionResult GetBituserByMail(string email)
        {
            Bituser bituser = db.Bitusers.Where(x => x.Email == email).FirstOrDefault();
            if (bituser == null)
            {
                return NotFound();
            }

            return Ok(bituser);
        }


        // PUT: api/Bitusers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBituser(int id, Bituser bituser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bituser.Id)
            {
                return BadRequest();
            }

            db.Entry(bituser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BituserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Bitusers
        [ResponseType(typeof(Bituser))]
        public IHttpActionResult PostBituser(Bituser bituser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bitusers.Add(bituser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bituser.Id }, bituser);
        }

        // DELETE: api/Bitusers/5
        [ResponseType(typeof(Bituser))]
        public IHttpActionResult DeleteBituser(int id)
        {
            Bituser bituser = db.Bitusers.Find(id);
            if (bituser == null)
            {
                return NotFound();
            }

            db.Bitusers.Remove(bituser);
            db.SaveChanges();

            return Ok(bituser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BituserExists(int id)
        {
            return db.Bitusers.Count(e => e.Id == id) > 0;
        }
    }
}