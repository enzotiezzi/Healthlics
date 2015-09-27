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
    public class PacientesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Pacientes
        public IQueryable<Paciente> GetPacientes()
        {
            return db.Pacientes;
        }

        // GET: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult GetPaciente(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // PUT: api/Pacientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaciente(int id, Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paciente.Id)
            {
                return BadRequest();
            }

            db.Entry(paciente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // POST: api/Pacientes
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult PostPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacientes.Add(paciente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paciente.Id }, paciente);
        }

        // DELETE: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult DeletePaciente(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            db.Pacientes.Remove(paciente);
            db.SaveChanges();

            return Ok(paciente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteExists(int id)
        {
            return db.Pacientes.Count(e => e.Id == id) > 0;
        }
    }
}