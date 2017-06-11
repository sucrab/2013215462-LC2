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
    public class LineaTelefonicaController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/LineaTelefonica
        public IQueryable<LineaTelefonica> GetLineaTelefonica()
        {
            return db.LineaTelefonica;
        }

        // GET api/LineaTelefonica/5
        [ResponseType(typeof(LineaTelefonica))]
        public IHttpActionResult GetLineaTelefonica(int id)
        {
            LineaTelefonica lineatelefonica = db.LineaTelefonica.Find(id);
            if (lineatelefonica == null)
            {
                return NotFound();
            }

            return Ok(lineatelefonica);
        }

        // PUT api/LineaTelefonica/5
        public IHttpActionResult PutLineaTelefonica(int id, LineaTelefonica lineatelefonica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineatelefonica.LineaTelefonicaID)
            {
                return BadRequest();
            }

            db.Entry(lineatelefonica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaTelefonicaExists(id))
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

        // POST api/LineaTelefonica
        [ResponseType(typeof(LineaTelefonica))]
        public IHttpActionResult PostLineaTelefonica(LineaTelefonica lineatelefonica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LineaTelefonica.Add(lineatelefonica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lineatelefonica.LineaTelefonicaID }, lineatelefonica);
        }

        // DELETE api/LineaTelefonica/5
        [ResponseType(typeof(LineaTelefonica))]
        public IHttpActionResult DeleteLineaTelefonica(int id)
        {
            LineaTelefonica lineatelefonica = db.LineaTelefonica.Find(id);
            if (lineatelefonica == null)
            {
                return NotFound();
            }

            db.LineaTelefonica.Remove(lineatelefonica);
            db.SaveChanges();

            return Ok(lineatelefonica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineaTelefonicaExists(int id)
        {
            return db.LineaTelefonica.Count(e => e.LineaTelefonicaID == id) > 0;
        }
    }
}