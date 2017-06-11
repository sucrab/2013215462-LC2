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
    public class EquipoCelularController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/EquipoCelular
        public IQueryable<EquipoCelular> GetEquipoCelular()
        {
            return db.EquipoCelular;
        }

        // GET api/EquipoCelular/5
        [ResponseType(typeof(EquipoCelular))]
        public IHttpActionResult GetEquipoCelular(int id)
        {
            EquipoCelular equipocelular = db.EquipoCelular.Find(id);
            if (equipocelular == null)
            {
                return NotFound();
            }

            return Ok(equipocelular);
        }

        // PUT api/EquipoCelular/5
        public IHttpActionResult PutEquipoCelular(int id, EquipoCelular equipocelular)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipocelular.EquipoCelularID)
            {
                return BadRequest();
            }

            db.Entry(equipocelular).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoCelularExists(id))
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

        // POST api/EquipoCelular
        [ResponseType(typeof(EquipoCelular))]
        public IHttpActionResult PostEquipoCelular(EquipoCelular equipocelular)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EquipoCelular.Add(equipocelular);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = equipocelular.EquipoCelularID }, equipocelular);
        }

        // DELETE api/EquipoCelular/5
        [ResponseType(typeof(EquipoCelular))]
        public IHttpActionResult DeleteEquipoCelular(int id)
        {
            EquipoCelular equipocelular = db.EquipoCelular.Find(id);
            if (equipocelular == null)
            {
                return NotFound();
            }

            db.EquipoCelular.Remove(equipocelular);
            db.SaveChanges();

            return Ok(equipocelular);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquipoCelularExists(int id)
        {
            return db.EquipoCelular.Count(e => e.EquipoCelularID == id) > 0;
        }
    }
}