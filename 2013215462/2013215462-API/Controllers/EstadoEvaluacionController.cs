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
    public class EstadoEvaluacionController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/EstadoEvaluacion
        public IQueryable<EstadoEvaluacion> GetEstadoEvaluacion()
        {
            return db.EstadoEvaluacion;
        }

        // GET api/EstadoEvaluacion/5
        [ResponseType(typeof(EstadoEvaluacion))]
        public IHttpActionResult GetEstadoEvaluacion(int id)
        {
            EstadoEvaluacion estadoevaluacion = db.EstadoEvaluacion.Find(id);
            if (estadoevaluacion == null)
            {
                return NotFound();
            }

            return Ok(estadoevaluacion);
        }

        // PUT api/EstadoEvaluacion/5
        public IHttpActionResult PutEstadoEvaluacion(int id, EstadoEvaluacion estadoevaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoevaluacion.EstadoEvaluacionID)
            {
                return BadRequest();
            }

            db.Entry(estadoevaluacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoEvaluacionExists(id))
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

        // POST api/EstadoEvaluacion
        [ResponseType(typeof(EstadoEvaluacion))]
        public IHttpActionResult PostEstadoEvaluacion(EstadoEvaluacion estadoevaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadoEvaluacion.Add(estadoevaluacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estadoevaluacion.EstadoEvaluacionID }, estadoevaluacion);
        }

        // DELETE api/EstadoEvaluacion/5
        [ResponseType(typeof(EstadoEvaluacion))]
        public IHttpActionResult DeleteEstadoEvaluacion(int id)
        {
            EstadoEvaluacion estadoevaluacion = db.EstadoEvaluacion.Find(id);
            if (estadoevaluacion == null)
            {
                return NotFound();
            }

            db.EstadoEvaluacion.Remove(estadoevaluacion);
            db.SaveChanges();

            return Ok(estadoevaluacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadoEvaluacionExists(int id)
        {
            return db.EstadoEvaluacion.Count(e => e.EstadoEvaluacionID == id) > 0;
        }
    }
}