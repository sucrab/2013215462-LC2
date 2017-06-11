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
    public class EvaluacionController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/Evaluacion
        public IQueryable<Evaluacion> GetEvaluacion()
        {
            return db.Evaluacion;
        }

        // GET api/Evaluacion/5
        [ResponseType(typeof(Evaluacion))]
        public IHttpActionResult GetEvaluacion(int id)
        {
            Evaluacion evaluacion = db.Evaluacion.Find(id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return Ok(evaluacion);
        }

        // PUT api/Evaluacion/5
        public IHttpActionResult PutEvaluacion(int id, Evaluacion evaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evaluacion.EvaluacionID)
            {
                return BadRequest();
            }

            db.Entry(evaluacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluacionExists(id))
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

        // POST api/Evaluacion
        [ResponseType(typeof(Evaluacion))]
        public IHttpActionResult PostEvaluacion(Evaluacion evaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Evaluacion.Add(evaluacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = evaluacion.EvaluacionID }, evaluacion);
        }

        // DELETE api/Evaluacion/5
        [ResponseType(typeof(Evaluacion))]
        public IHttpActionResult DeleteEvaluacion(int id)
        {
            Evaluacion evaluacion = db.Evaluacion.Find(id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            db.Evaluacion.Remove(evaluacion);
            db.SaveChanges();

            return Ok(evaluacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EvaluacionExists(int id)
        {
            return db.Evaluacion.Count(e => e.EvaluacionID == id) > 0;
        }
    }
}