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
    public class ProvinciaController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/Provincia
        public IQueryable<Provincia> GetProvincia()
        {
            return db.Provincia;
        }

        // GET api/Provincia/5
        [ResponseType(typeof(Provincia))]
        public IHttpActionResult GetProvincia(int id)
        {
            Provincia provincia = db.Provincia.Find(id);
            if (provincia == null)
            {
                return NotFound();
            }

            return Ok(provincia);
        }

        // PUT api/Provincia/5
        public IHttpActionResult PutProvincia(int id, Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != provincia.ProvinciaID)
            {
                return BadRequest();
            }

            db.Entry(provincia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinciaExists(id))
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

        // POST api/Provincia
        [ResponseType(typeof(Provincia))]
        public IHttpActionResult PostProvincia(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Provincia.Add(provincia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = provincia.ProvinciaID }, provincia);
        }

        // DELETE api/Provincia/5
        [ResponseType(typeof(Provincia))]
        public IHttpActionResult DeleteProvincia(int id)
        {
            Provincia provincia = db.Provincia.Find(id);
            if (provincia == null)
            {
                return NotFound();
            }

            db.Provincia.Remove(provincia);
            db.SaveChanges();

            return Ok(provincia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProvinciaExists(int id)
        {
            return db.Provincia.Count(e => e.ProvinciaID == id) > 0;
        }
    }
}