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
    public class TipoPlanController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/TipoPlan
        public IQueryable<TipoPlan> GetTipoPlan()
        {
            return db.TipoPlan;
        }

        // GET api/TipoPlan/5
        [ResponseType(typeof(TipoPlan))]
        public IHttpActionResult GetTipoPlan(int id)
        {
            TipoPlan tipoplan = db.TipoPlan.Find(id);
            if (tipoplan == null)
            {
                return NotFound();
            }

            return Ok(tipoplan);
        }

        // PUT api/TipoPlan/5
        public IHttpActionResult PutTipoPlan(int id, TipoPlan tipoplan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoplan.TipoPlanID)
            {
                return BadRequest();
            }

            db.Entry(tipoplan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPlanExists(id))
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

        // POST api/TipoPlan
        [ResponseType(typeof(TipoPlan))]
        public IHttpActionResult PostTipoPlan(TipoPlan tipoplan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoPlan.Add(tipoplan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoplan.TipoPlanID }, tipoplan);
        }

        // DELETE api/TipoPlan/5
        [ResponseType(typeof(TipoPlan))]
        public IHttpActionResult DeleteTipoPlan(int id)
        {
            TipoPlan tipoplan = db.TipoPlan.Find(id);
            if (tipoplan == null)
            {
                return NotFound();
            }

            db.TipoPlan.Remove(tipoplan);
            db.SaveChanges();

            return Ok(tipoplan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoPlanExists(int id)
        {
            return db.TipoPlan.Count(e => e.TipoPlanID == id) > 0;
        }
    }
}