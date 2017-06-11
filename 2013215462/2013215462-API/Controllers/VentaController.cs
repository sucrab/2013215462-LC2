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
    public class VentaController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/Venta
        public IQueryable<Venta> GetVenta()
        {
            return db.Venta;
        }

        // GET api/Venta/5
        [ResponseType(typeof(Venta))]
        public IHttpActionResult GetVenta(int id)
        {
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return NotFound();
            }

            return Ok(venta);
        }

        // PUT api/Venta/5
        public IHttpActionResult PutVenta(int id, Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venta.VentaID)
            {
                return BadRequest();
            }

            db.Entry(venta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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

        // POST api/Venta
        [ResponseType(typeof(Venta))]
        public IHttpActionResult PostVenta(Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Venta.Add(venta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = venta.VentaID }, venta);
        }

        // DELETE api/Venta/5
        [ResponseType(typeof(Venta))]
        public IHttpActionResult DeleteVenta(int id)
        {
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return NotFound();
            }

            db.Venta.Remove(venta);
            db.SaveChanges();

            return Ok(venta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VentaExists(int id)
        {
            return db.Venta.Count(e => e.VentaID == id) > 0;
        }
    }
}