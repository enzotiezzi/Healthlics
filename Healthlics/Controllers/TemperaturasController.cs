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
    public class TemperaturasController : ApiController
    {
        private Context db = new Context();

        // GET: api/Temperaturas
        public IQueryable<Temperatura> GetTemperaturas()
        {
            return db.Temperaturas;
        }

        // GET: api/Temperaturas/5
        [ResponseType(typeof(Temperatura))]
        public IHttpActionResult GetTemperatura(int id)
        {
            Temperatura temperatura = db.Temperaturas.Find(id);
            if (temperatura == null)
            {
                return NotFound();
            }

            return Ok(temperatura);
        }

        // PUT: api/Temperaturas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTemperatura(int id, Temperatura temperatura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != temperatura.Id)
            {
                return BadRequest();
            }

            db.Entry(temperatura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperaturaExists(id))
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

        // POST: api/Temperaturas
        [ResponseType(typeof(Temperatura))]
        public IHttpActionResult PostTemperatura(Temperatura temperatura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Temperaturas.Add(temperatura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = temperatura.Id }, temperatura);
        }

        // DELETE: api/Temperaturas/5
        [ResponseType(typeof(Temperatura))]
        public IHttpActionResult DeleteTemperatura(int id)
        {
            Temperatura temperatura = db.Temperaturas.Find(id);
            if (temperatura == null)
            {
                return NotFound();
            }

            db.Temperaturas.Remove(temperatura);
            db.SaveChanges();

            return Ok(temperatura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TemperaturaExists(int id)
        {
            return db.Temperaturas.Count(e => e.Id == id) > 0;
        }
    }
}