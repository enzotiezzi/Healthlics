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
    public class PacienteAnaminesiaFisicasController : ApiController
    {
        private Context db = new Context();

        // GET: api/PacienteAnaminesiaFisicas
        public IQueryable<PacienteAnaminesiaFisica> GetPacienteAnaminesiaFisicas()
        {
            return db.PacienteAnaminesiaFisicas;
        }

        // GET: api/PacienteAnaminesiaFisicas/5
        [ResponseType(typeof(PacienteAnaminesiaFisica))]
        public IHttpActionResult GetPacienteAnaminesiaFisica(int id)
        {
            PacienteAnaminesiaFisica pacienteAnaminesiaFisica = db.PacienteAnaminesiaFisicas.Find(id);
            if (pacienteAnaminesiaFisica == null)
            {
                return NotFound();
            }

            return Ok(pacienteAnaminesiaFisica);
        }

        // PUT: api/PacienteAnaminesiaFisicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacienteAnaminesiaFisica(int id, PacienteAnaminesiaFisica pacienteAnaminesiaFisica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacienteAnaminesiaFisica.Id)
            {
                return BadRequest();
            }

            db.Entry(pacienteAnaminesiaFisica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteAnaminesiaFisicaExists(id))
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

        // POST: api/PacienteAnaminesiaFisicas
        [ResponseType(typeof(PacienteAnaminesiaFisica))]
        public IHttpActionResult PostPacienteAnaminesiaFisica(PacienteAnaminesiaFisica pacienteAnaminesiaFisica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PacienteAnaminesiaFisicas.Add(pacienteAnaminesiaFisica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pacienteAnaminesiaFisica.Id }, pacienteAnaminesiaFisica);
        }

        // DELETE: api/PacienteAnaminesiaFisicas/5
        [ResponseType(typeof(PacienteAnaminesiaFisica))]
        public IHttpActionResult DeletePacienteAnaminesiaFisica(int id)
        {
            PacienteAnaminesiaFisica pacienteAnaminesiaFisica = db.PacienteAnaminesiaFisicas.Find(id);
            if (pacienteAnaminesiaFisica == null)
            {
                return NotFound();
            }

            db.PacienteAnaminesiaFisicas.Remove(pacienteAnaminesiaFisica);
            db.SaveChanges();

            return Ok(pacienteAnaminesiaFisica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteAnaminesiaFisicaExists(int id)
        {
            return db.PacienteAnaminesiaFisicas.Count(e => e.Id == id) > 0;
        }
    }
}