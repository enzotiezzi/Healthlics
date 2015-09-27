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
    public class PressaosController : ApiController
    {
        private Context db = new Context();

        // GET: api/Pressaos
        public IQueryable<Pressao> GetPressaos()
        {
            return db.Pressaos;
        }

        // GET: api/Pressaos/5
        [ResponseType(typeof(Pressao))]
        public IHttpActionResult GetPressao(int id)
        {
            Pressao pressao = db.Pressaos.Find(id);
            if (pressao == null)
            {
                return NotFound();
            }

            return Ok(pressao);
        }

        // PUT: api/Pressaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPressao(int id, Pressao pressao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pressao.Id)
            {
                return BadRequest();
            }

            db.Entry(pressao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PressaoExists(id))
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

        // POST: api/Pressaos
        [ResponseType(typeof(Pressao))]
        public IHttpActionResult PostPressao(Pressao pressao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pressaos.Add(pressao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pressao.Id }, pressao);
        }

        // DELETE: api/Pressaos/5
        [ResponseType(typeof(Pressao))]
        public IHttpActionResult DeletePressao(int id)
        {
            Pressao pressao = db.Pressaos.Find(id);
            if (pressao == null)
            {
                return NotFound();
            }

            db.Pressaos.Remove(pressao);
            db.SaveChanges();

            return Ok(pressao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PressaoExists(int id)
        {
            return db.Pressaos.Count(e => e.Id == id) > 0;
        }
    }
}