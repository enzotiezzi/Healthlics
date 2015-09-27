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
    public class PacienteRemediosController : ApiController
    {
        private Context db = new Context();

        // GET: api/PacienteRemedios
        public IQueryable<PacienteRemedio> GetPacienteRemedios()
        {
            return db.PacienteRemedios;
        }

        // GET: api/PacienteRemedios/5
        [ResponseType(typeof(PacienteRemedio))]
        public IHttpActionResult GetPacienteRemedio(int id)
        {
            PacienteRemedio pacienteRemedio = db.PacienteRemedios.Find(id);
            if (pacienteRemedio == null)
            {
                return NotFound();
            }

            return Ok(pacienteRemedio);
        }

        // PUT: api/PacienteRemedios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacienteRemedio(int id, PacienteRemedio pacienteRemedio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacienteRemedio.Id)
            {
                return BadRequest();
            }

            db.Entry(pacienteRemedio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteRemedioExists(id))
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

        // POST: api/PacienteRemedios
        [ResponseType(typeof(PacienteRemedio))]
        public IHttpActionResult PostPacienteRemedio(PacienteRemedio pacienteRemedio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PacienteRemedios.Add(pacienteRemedio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pacienteRemedio.Id }, pacienteRemedio);
        }

        // DELETE: api/PacienteRemedios/5
        [ResponseType(typeof(PacienteRemedio))]
        public IHttpActionResult DeletePacienteRemedio(int id)
        {
            PacienteRemedio pacienteRemedio = db.PacienteRemedios.Find(id);
            if (pacienteRemedio == null)
            {
                return NotFound();
            }

            db.PacienteRemedios.Remove(pacienteRemedio);
            db.SaveChanges();

            return Ok(pacienteRemedio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteRemedioExists(int id)
        {
            return db.PacienteRemedios.Count(e => e.Id == id) > 0;
        }
    }
}