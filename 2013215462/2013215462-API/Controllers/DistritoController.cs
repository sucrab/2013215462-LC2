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
using _2013215462_ENT;
using _2013215462_PER;

namespace _2013215462_API.Controllers
{
    public class DistritoController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/Distrito
        public IQueryable<Distrito> GetDistrito()
        {
            return db.Distrito;
        }

        // GET api/Distrito/5
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult GetDistrito(int id)
        {
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return NotFound();
            }

            return Ok(distrito);
        }

        // PUT api/Distrito/5
        public IHttpActionResult PutDistrito(int id, Distrito distrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != distrito.DistritoID)
            {
                return BadRequest();
            }

            db.Entry(distrito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistritoExists(id))
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

        // POST api/Distrito
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult PostDistrito(Distrito distrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Distrito.Add(distrito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = distrito.DistritoID }, distrito);
        }

        // DELETE api/Distrito/5
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult DeleteDistrito(int id)
        {
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return NotFound();
            }

            db.Distrito.Remove(distrito);
            db.SaveChanges();

            return Ok(distrito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistritoExists(int id)
        {
            return db.Distrito.Count(e => e.DistritoID == id) > 0;
        }
    }
}