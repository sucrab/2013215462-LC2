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
    public class AdministradorEquipoController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/AdministradorEquipo
        public IQueryable<AdministradorEquipo> GetAdministradorEquipo()
        {   
            return db.AdministradorEquipo;
        }

        // GET api/AdministradorEquipo/5
        [ResponseType(typeof(AdministradorEquipo))]
        public IHttpActionResult GetAdministradorEquipo(int id)
        {
            AdministradorEquipo administradorequipo = db.AdministradorEquipo.Find(id);
            if (administradorequipo == null)
            {
                return NotFound();
            }

            return Ok(administradorequipo);
        }

        // PUT api/AdministradorEquipo/5
        public IHttpActionResult PutAdministradorEquipo(int id, AdministradorEquipo administradorequipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administradorequipo.AdministradorEquipoID)
            {
                return BadRequest();
            }

            db.Entry(administradorequipo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorEquipoExists(id))
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

        // POST api/AdministradorEquipo
        [ResponseType(typeof(AdministradorEquipo))]
        public IHttpActionResult PostAdministradorEquipo(AdministradorEquipo administradorequipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdministradorEquipo.Add(administradorequipo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = administradorequipo.AdministradorEquipoID }, administradorequipo);
        }

        // DELETE api/AdministradorEquipo/5
        [ResponseType(typeof(AdministradorEquipo))]
        public IHttpActionResult DeleteAdministradorEquipo(int id)
        {
            AdministradorEquipo administradorequipo = db.AdministradorEquipo.Find(id);
            if (administradorequipo == null)
            {
                return NotFound();
            }

            db.AdministradorEquipo.Remove(administradorequipo);
            db.SaveChanges();

            return Ok(administradorequipo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministradorEquipoExists(int id)
        {
            return db.AdministradorEquipo.Count(e => e.AdministradorEquipoID == id) > 0;
        }
    }
}