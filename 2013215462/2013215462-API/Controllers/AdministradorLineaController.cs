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
    public class AdministradorLineaController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/AdministradorLinea
        public IQueryable<AdministradorLinea> GetAdministradorLinea()
        {
            return db.AdministradorLinea;
        }

        // GET api/AdministradorLinea/5
        [ResponseType(typeof(AdministradorLinea))]
        public IHttpActionResult GetAdministradorLinea(int id)
        {
            AdministradorLinea administradorlinea = db.AdministradorLinea.Find(id);
            if (administradorlinea == null)
            {
                return NotFound();
            }

            return Ok(administradorlinea);
        }

        // PUT api/AdministradorLinea/5
        public IHttpActionResult PutAdministradorLinea(int id, AdministradorLinea administradorlinea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administradorlinea.AdministradorLineaID)
            {
                return BadRequest();
            }

            db.Entry(administradorlinea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorLineaExists(id))
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

        // POST api/AdministradorLinea
        [ResponseType(typeof(AdministradorLinea))]
        public IHttpActionResult PostAdministradorLinea(AdministradorLinea administradorlinea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdministradorLinea.Add(administradorlinea);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = administradorlinea.AdministradorLineaID }, administradorlinea);
        }

        // DELETE api/AdministradorLinea/5
        [ResponseType(typeof(AdministradorLinea))]
        public IHttpActionResult DeleteAdministradorLinea(int id)
        {
            AdministradorLinea administradorlinea = db.AdministradorLinea.Find(id);
            if (administradorlinea == null)
            {
                return NotFound();
            }

            db.AdministradorLinea.Remove(administradorlinea);
            db.SaveChanges();

            return Ok(administradorlinea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministradorLineaExists(int id)
        {
            return db.AdministradorLinea.Count(e => e.AdministradorLineaID == id) > 0;
        }
    }
}