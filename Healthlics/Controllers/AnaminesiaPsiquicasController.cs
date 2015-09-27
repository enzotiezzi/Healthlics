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
    public class AnaminesiaPsiquicasController : ApiController
    {
        private Context db = new Context();

        // GET: api/AnaminesiaPsiquicas
        public IQueryable<AnaminesiaPsiquica> GetAnaminesiaPsiquicas()
        {
            return db.AnaminesiaPsiquicas;
        }

        // GET: api/AnaminesiaPsiquicas/5
        [ResponseType(typeof(AnaminesiaPsiquica))]
        public IHttpActionResult GetAnaminesiaPsiquica(int id)
        {
            AnaminesiaPsiquica anaminesiaPsiquica = db.AnaminesiaPsiquicas.Find(id);
            if (anaminesiaPsiquica == null)
            {
                return NotFound();
            }

            return Ok(anaminesiaPsiquica);
        }

        // PUT: api/AnaminesiaPsiquicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnaminesiaPsiquica(int id, AnaminesiaPsiquica anaminesiaPsiquica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anaminesiaPsiquica.Id)
            {
                return BadRequest();
            }

            db.Entry(anaminesiaPsiquica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnaminesiaPsiquicaExists(id))
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

        // POST: api/AnaminesiaPsiquicas
        [ResponseType(typeof(AnaminesiaPsiquica))]
        public IHttpActionResult PostAnaminesiaPsiquica(AnaminesiaPsiquica anaminesiaPsiquica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnaminesiaPsiquicas.Add(anaminesiaPsiquica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = anaminesiaPsiquica.Id }, anaminesiaPsiquica);
        }

        // DELETE: api/AnaminesiaPsiquicas/5
        [ResponseType(typeof(AnaminesiaPsiquica))]
        public IHttpActionResult DeleteAnaminesiaPsiquica(int id)
        {
            AnaminesiaPsiquica anaminesiaPsiquica = db.AnaminesiaPsiquicas.Find(id);
            if (anaminesiaPsiquica == null)
            {
                return NotFound();
            }

            db.AnaminesiaPsiquicas.Remove(anaminesiaPsiquica);
            db.SaveChanges();

            return Ok(anaminesiaPsiquica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnaminesiaPsiquicaExists(int id)
        {
            return db.AnaminesiaPsiquicas.Count(e => e.Id == id) > 0;
        }
    }
}