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
    public class TipoLineaController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/TipoLinea
        public IQueryable<TipoLinea> GetTipoLinea()
        {
            return db.TipoLinea;
        }

        // GET api/TipoLinea/5
        [ResponseType(typeof(TipoLinea))]
        public IHttpActionResult GetTipoLinea(int id)
        {
            TipoLinea tipolinea = db.TipoLinea.Find(id);
            if (tipolinea == null)
            {
                return NotFound();
            }

            return Ok(tipolinea);
        }

        // PUT api/TipoLinea/5
        public IHttpActionResult PutTipoLinea(int id, TipoLinea tipolinea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipolinea.TipoLineaID)
            {
                return BadRequest();
            }

            db.Entry(tipolinea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoLineaExists(id))
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

        // POST api/TipoLinea
        [ResponseType(typeof(TipoLinea))]
        public IHttpActionResult PostTipoLinea(TipoLinea tipolinea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoLinea.Add(tipolinea);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipolinea.TipoLineaID }, tipolinea);
        }

        // DELETE api/TipoLinea/5
        [ResponseType(typeof(TipoLinea))]
        public IHttpActionResult DeleteTipoLinea(int id)
        {
            TipoLinea tipolinea = db.TipoLinea.Find(id);
            if (tipolinea == null)
            {
                return NotFound();
            }

            db.TipoLinea.Remove(tipolinea);
            db.SaveChanges();

            return Ok(tipolinea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoLineaExists(int id)
        {
            return db.TipoLinea.Count(e => e.TipoLineaID == id) > 0;
        }
    }
}