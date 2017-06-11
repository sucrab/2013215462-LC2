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
    public class TipoEvaluacionController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/TipoEvaluacion
        public IQueryable<TipoEvaluacion> GetTipoEvaluacion()
        {
            return db.TipoEvaluacion;
        }

        // GET api/TipoEvaluacion/5
        [ResponseType(typeof(TipoEvaluacion))]
        public IHttpActionResult GetTipoEvaluacion(int id)
        {
            TipoEvaluacion tipoevaluacion = db.TipoEvaluacion.Find(id);
            if (tipoevaluacion == null)
            {
                return NotFound();
            }

            return Ok(tipoevaluacion);
        }

        // PUT api/TipoEvaluacion/5
        public IHttpActionResult PutTipoEvaluacion(int id, TipoEvaluacion tipoevaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoevaluacion.TipoEvaluacionID)
            {
                return BadRequest();
            }

            db.Entry(tipoevaluacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEvaluacionExists(id))
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

        // POST api/TipoEvaluacion
        [ResponseType(typeof(TipoEvaluacion))]
        public IHttpActionResult PostTipoEvaluacion(TipoEvaluacion tipoevaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoEvaluacion.Add(tipoevaluacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoevaluacion.TipoEvaluacionID }, tipoevaluacion);
        }

        // DELETE api/TipoEvaluacion/5
        [ResponseType(typeof(TipoEvaluacion))]
        public IHttpActionResult DeleteTipoEvaluacion(int id)
        {
            TipoEvaluacion tipoevaluacion = db.TipoEvaluacion.Find(id);
            if (tipoevaluacion == null)
            {
                return NotFound();
            }

            db.TipoEvaluacion.Remove(tipoevaluacion);
            db.SaveChanges();

            return Ok(tipoevaluacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoEvaluacionExists(int id)
        {
            return db.TipoEvaluacion.Count(e => e.TipoEvaluacionID == id) > 0;
        }
    }
}