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
    public class CentroAtencionController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/CentroAtencion
        public IQueryable<CentroAtencion> GetCentroAtencion()
        {
            return db.CentroAtencion;
        }

        // GET api/CentroAtencion/5
        [ResponseType(typeof(CentroAtencion))]
        public IHttpActionResult GetCentroAtencion(int id)
        {
            CentroAtencion centroatencion = db.CentroAtencion.Find(id);
            if (centroatencion == null)
            {
                return NotFound();
            }

            return Ok(centroatencion);
        }

        // PUT api/CentroAtencion/5
        public IHttpActionResult PutCentroAtencion(int id, CentroAtencion centroatencion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != centroatencion.CentroAtencionID)
            {
                return BadRequest();
            }

            db.Entry(centroatencion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentroAtencionExists(id))
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

        // POST api/CentroAtencion
        [ResponseType(typeof(CentroAtencion))]
        public IHttpActionResult PostCentroAtencion(CentroAtencion centroatencion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CentroAtencion.Add(centroatencion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = centroatencion.CentroAtencionID }, centroatencion);
        }

        // DELETE api/CentroAtencion/5
        [ResponseType(typeof(CentroAtencion))]
        public IHttpActionResult DeleteCentroAtencion(int id)
        {
            CentroAtencion centroatencion = db.CentroAtencion.Find(id);
            if (centroatencion == null)
            {
                return NotFound();
            }

            db.CentroAtencion.Remove(centroatencion);
            db.SaveChanges();

            return Ok(centroatencion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CentroAtencionExists(int id)
        {
            return db.CentroAtencion.Count(e => e.CentroAtencionID == id) > 0;
        }
    }
}