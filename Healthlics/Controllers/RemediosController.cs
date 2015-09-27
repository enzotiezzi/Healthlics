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
    public class RemediosController : ApiController
    {
        private Context db = new Context();

        // GET: api/Remedios
        public IQueryable<Remedio> GetRemedios()
        {
            return db.Remedios;
        }

        // GET: api/Remedios/5
        [ResponseType(typeof(Remedio))]
        public IHttpActionResult GetRemedio(int id)
        {
            Remedio remedio = db.Remedios.Find(id);
            if (remedio == null)
            {
                return NotFound();
            }

            return Ok(remedio);
        }

        // PUT: api/Remedios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRemedio(int id, Remedio remedio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != remedio.Id)
            {
                return BadRequest();
            }

            db.Entry(remedio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemedioExists(id))
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

        // POST: api/Remedios
        [ResponseType(typeof(Remedio))]
        public IHttpActionResult PostRemedio(Remedio remedio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Remedios.Add(remedio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = remedio.Id }, remedio);
        }

        // DELETE: api/Remedios/5
        [ResponseType(typeof(Remedio))]
        public IHttpActionResult DeleteRemedio(int id)
        {
            Remedio remedio = db.Remedios.Find(id);
            if (remedio == null)
            {
                return NotFound();
            }

            db.Remedios.Remove(remedio);
            db.SaveChanges();

            return Ok(remedio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RemedioExists(int id)
        {
            return db.Remedios.Count(e => e.Id == id) > 0;
        }
    }
}