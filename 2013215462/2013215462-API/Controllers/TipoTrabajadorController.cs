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
    public class TipoTrabajadorController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/TipoTrabajador
        public IQueryable<TipoTrabajador> GetTipoTrabajador()
        {
            return db.TipoTrabajador;
        }

        // GET api/TipoTrabajador/5
        [ResponseType(typeof(TipoTrabajador))]
        public IHttpActionResult GetTipoTrabajador(int id)
        {
            TipoTrabajador tipotrabajador = db.TipoTrabajador.Find(id);
            if (tipotrabajador == null)
            {
                return NotFound();
            }

            return Ok(tipotrabajador);
        }

        // PUT api/TipoTrabajador/5
        public IHttpActionResult PutTipoTrabajador(int id, TipoTrabajador tipotrabajador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipotrabajador.TipoTrabajadorID)
            {
                return BadRequest();
            }

            db.Entry(tipotrabajador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTrabajadorExists(id))
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

        // POST api/TipoTrabajador
        [ResponseType(typeof(TipoTrabajador))]
        public IHttpActionResult PostTipoTrabajador(TipoTrabajador tipotrabajador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoTrabajador.Add(tipotrabajador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipotrabajador.TipoTrabajadorID }, tipotrabajador);
        }

        // DELETE api/TipoTrabajador/5
        [ResponseType(typeof(TipoTrabajador))]
        public IHttpActionResult DeleteTipoTrabajador(int id)
        {
            TipoTrabajador tipotrabajador = db.TipoTrabajador.Find(id);
            if (tipotrabajador == null)
            {
                return NotFound();
            }

            db.TipoTrabajador.Remove(tipotrabajador);
            db.SaveChanges();

            return Ok(tipotrabajador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoTrabajadorExists(int id)
        {
            return db.TipoTrabajador.Count(e => e.TipoTrabajadorID == id) > 0;
        }
    }
}