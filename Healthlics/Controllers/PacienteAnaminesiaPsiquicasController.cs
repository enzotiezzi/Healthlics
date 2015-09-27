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
    public class PacienteAnaminesiaPsiquicasController : ApiController
    {
        private Context db = new Context();

        // GET: api/PacienteAnaminesiaPsiquicas
        public IQueryable<PacienteAnaminesiaPsiquica> GetPacienteAnaminesiaPsiquicas()
        {
            return db.PacienteAnaminesiaPsiquicas;
        }

        // GET: api/PacienteAnaminesiaPsiquicas/5
        [ResponseType(typeof(PacienteAnaminesiaPsiquica))]
        public IHttpActionResult GetPacienteAnaminesiaPsiquica(int id)
        {
            PacienteAnaminesiaPsiquica pacienteAnaminesiaPsiquica = db.PacienteAnaminesiaPsiquicas.Find(id);
            if (pacienteAnaminesiaPsiquica == null)
            {
                return NotFound();
            }

            return Ok(pacienteAnaminesiaPsiquica);
        }

        // PUT: api/PacienteAnaminesiaPsiquicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacienteAnaminesiaPsiquica(int id, PacienteAnaminesiaPsiquica pacienteAnaminesiaPsiquica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacienteAnaminesiaPsiquica.Id)
            {
                return BadRequest();
            }

            db.Entry(pacienteAnaminesiaPsiquica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteAnaminesiaPsiquicaExists(id))
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

        // POST: api/PacienteAnaminesiaPsiquicas
        [ResponseType(typeof(PacienteAnaminesiaPsiquica))]
        public IHttpActionResult PostPacienteAnaminesiaPsiquica(PacienteAnaminesiaPsiquica pacienteAnaminesiaPsiquica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PacienteAnaminesiaPsiquicas.Add(pacienteAnaminesiaPsiquica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pacienteAnaminesiaPsiquica.Id }, pacienteAnaminesiaPsiquica);
        }

        // DELETE: api/PacienteAnaminesiaPsiquicas/5
        [ResponseType(typeof(PacienteAnaminesiaPsiquica))]
        public IHttpActionResult DeletePacienteAnaminesiaPsiquica(int id)
        {
            PacienteAnaminesiaPsiquica pacienteAnaminesiaPsiquica = db.PacienteAnaminesiaPsiquicas.Find(id);
            if (pacienteAnaminesiaPsiquica == null)
            {
                return NotFound();
            }

            db.PacienteAnaminesiaPsiquicas.Remove(pacienteAnaminesiaPsiquica);
            db.SaveChanges();

            return Ok(pacienteAnaminesiaPsiquica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteAnaminesiaPsiquicaExists(int id)
        {
            return db.PacienteAnaminesiaPsiquicas.Count(e => e.Id == id) > 0;
        }
    }
}