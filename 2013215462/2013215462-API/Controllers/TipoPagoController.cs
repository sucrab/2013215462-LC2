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
    public class TipoPagoController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/TipoPago
        public IQueryable<TipoPago> GetTipoPago()
        {
            return db.TipoPago;
        }

        // GET api/TipoPago/5
        [ResponseType(typeof(TipoPago))]
        public IHttpActionResult GetTipoPago(int id)
        {
            TipoPago tipopago = db.TipoPago.Find(id);
            if (tipopago == null)
            {
                return NotFound();
            }

            return Ok(tipopago);
        }

        // PUT api/TipoPago/5
        public IHttpActionResult PutTipoPago(int id, TipoPago tipopago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipopago.TipoPagoID)
            {
                return BadRequest();
            }

            db.Entry(tipopago).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPagoExists(id))
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

        // POST api/TipoPago
        [ResponseType(typeof(TipoPago))]
        public IHttpActionResult PostTipoPago(TipoPago tipopago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoPago.Add(tipopago);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipopago.TipoPagoID }, tipopago);
        }

        // DELETE api/TipoPago/5
        [ResponseType(typeof(TipoPago))]
        public IHttpActionResult DeleteTipoPago(int id)
        {
            TipoPago tipopago = db.TipoPago.Find(id);
            if (tipopago == null)
            {
                return NotFound();
            }

            db.TipoPago.Remove(tipopago);
            db.SaveChanges();

            return Ok(tipopago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoPagoExists(int id)
        {
            return db.TipoPago.Count(e => e.TipoPagoID == id) > 0;
        }
    }
}