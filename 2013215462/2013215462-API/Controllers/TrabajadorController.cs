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
    public class TrabajadorController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/Trabajador
        public IQueryable<Trabajador> GetTrabajador()
        {
            return db.Trabajador;
        }

        // GET api/Trabajador/5
        [ResponseType(typeof(Trabajador))]
        public IHttpActionResult GetTrabajador(int id)
        {
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return Ok(trabajador);
        }

        // PUT api/Trabajador/5
        public IHttpActionResult PutTrabajador(int id, Trabajador trabajador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trabajador.TrabajadorID)
            {
                return BadRequest();
            }

            db.Entry(trabajador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajadorExists(id))
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

        // POST api/Trabajador
        [ResponseType(typeof(Trabajador))]
        public IHttpActionResult PostTrabajador(Trabajador trabajador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trabajador.Add(trabajador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trabajador.TrabajadorID }, trabajador);
        }

        // DELETE api/Trabajador/5
        [ResponseType(typeof(Trabajador))]
        public IHttpActionResult DeleteTrabajador(int id)
        {
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return NotFound();
            }

            db.Trabajador.Remove(trabajador);
            db.SaveChanges();

            return Ok(trabajador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrabajadorExists(int id)
        {
            return db.Trabajador.Count(e => e.TrabajadorID == id) > 0;
        }
    }
}