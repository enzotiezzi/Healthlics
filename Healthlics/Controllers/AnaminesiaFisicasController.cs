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
using Healthlics;
using Healthlics.Models;

namespace Healthlics.Controllers
{
    public class AnaminesiaFisicasController : ApiController
    {
        private Context db = new Context();

        // GET: api/AnaminesiaFisicas
        public IQueryable<AnaminesiaFisica> GetAnaminesiaFisicas()
        {
            return db.AnaminesiaFisicas;
        }

        // GET: api/AnaminesiaFisicas/5
        [ResponseType(typeof(AnaminesiaFisica))]
        public IHttpActionResult GetAnaminesiaFisica(int id)
        {
            AnaminesiaFisica anaminesiaFisica = db.AnaminesiaFisicas.Find(id);
            if (anaminesiaFisica == null)
            {
                return NotFound();
            }

            return Ok(anaminesiaFisica);
        }

        // PUT: api/AnaminesiaFisicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnaminesiaFisica(int id, AnaminesiaFisica anaminesiaFisica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anaminesiaFisica.Id)
            {
                return BadRequest();
            }

            db.Entry(anaminesiaFisica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnaminesiaFisicaExists(id))
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

        // POST: api/AnaminesiaFisicas
        [ResponseType(typeof(AnaminesiaFisica))]
        public IHttpActionResult PostAnaminesiaFisica(AnaminesiaFisica anaminesiaFisica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnaminesiaFisicas.Add(anaminesiaFisica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = anaminesiaFisica.Id }, anaminesiaFisica);
        }

        // DELETE: api/AnaminesiaFisicas/5
        [ResponseType(typeof(AnaminesiaFisica))]
        public IHttpActionResult DeleteAnaminesiaFisica(int id)
        {
            AnaminesiaFisica anaminesiaFisica = db.AnaminesiaFisicas.Find(id);
            if (anaminesiaFisica == null)
            {
                return NotFound();
            }

            db.AnaminesiaFisicas.Remove(anaminesiaFisica);
            db.SaveChanges();

            return Ok(anaminesiaFisica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnaminesiaFisicaExists(int id)
        {
            return db.AnaminesiaFisicas.Count(e => e.Id == id) > 0;
        }
    }
}