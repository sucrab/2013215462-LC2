﻿using System;
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
    public class ContratoController : ApiController
    {
        private DiazDbContext db = new DiazDbContext();

        // GET api/Contrato
        public IQueryable<Contrato> GetContrato()
        {
            return db.Contrato;
        }

        // GET api/Contrato/5
        [ResponseType(typeof(Contrato))]
        public IHttpActionResult GetContrato(int id)
        {
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return NotFound();
            }

            return Ok(contrato);
        }

        // PUT api/Contrato/5
        public IHttpActionResult PutContrato(int id, Contrato contrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contrato.ContratoID)
            {
                return BadRequest();
            }

            db.Entry(contrato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(id))
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

        // POST api/Contrato
        [ResponseType(typeof(Contrato))]
        public IHttpActionResult PostContrato(Contrato contrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contrato.Add(contrato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contrato.ContratoID }, contrato);
        }

        // DELETE api/Contrato/5
        [ResponseType(typeof(Contrato))]
        public IHttpActionResult DeleteContrato(int id)
        {
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return NotFound();
            }

            db.Contrato.Remove(contrato);
            db.SaveChanges();

            return Ok(contrato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContratoExists(int id)
        {
            return db.Contrato.Count(e => e.ContratoID == id) > 0;
        }
    }
}