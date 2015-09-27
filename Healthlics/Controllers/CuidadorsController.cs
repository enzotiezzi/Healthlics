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
    public class CuidadorsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Cuidadors
        public IQueryable<Cuidador> GetCuidadors()
        {
            return db.Cuidadors;
        }

        // GET: api/Cuidadors/5
        [ResponseType(typeof(Cuidador))]
        public IHttpActionResult GetCuidador(int id)
        {
            Cuidador cuidador = db.Cuidadors.Find(id);
            if (cuidador == null)
            {
                return NotFound();
            }

            return Ok(cuidador);
        }

        // PUT: api/Cuidadors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuidador(int id, Cuidador cuidador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuidador.Id)
            {
                return BadRequest();
            }

            db.Entry(cuidador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuidadorExists(id))
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

        // POST: api/Cuidadors
        [ResponseType(typeof(Cuidador))]
        public IHttpActionResult PostCuidador(Cuidador cuidador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cuidadors.Add(cuidador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cuidador.Id }, cuidador);
        }

        // DELETE: api/Cuidadors/5
        [ResponseType(typeof(Cuidador))]
        public IHttpActionResult DeleteCuidador(int id)
        {
            Cuidador cuidador = db.Cuidadors.Find(id);
            if (cuidador == null)
            {
                return NotFound();
            }

            db.Cuidadors.Remove(cuidador);
            db.SaveChanges();

            return Ok(cuidador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuidadorExists(int id)
        {
            return db.Cuidadors.Count(e => e.Id == id) > 0;
        }
    }
}