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
    public class ObservacaosController : ApiController
    {
        private Context db = new Context();

        // GET: api/Observacaos
        public IQueryable<Observacao> GetObservacaos()
        {
            return db.Observacaos;
        }

        // GET: api/Observacaos/5
        [ResponseType(typeof(Observacao))]
        public IHttpActionResult GetObservacao(int id)
        {
            Observacao observacao = db.Observacaos.Find(id);
            if (observacao == null)
            {
                return NotFound();
            }

            return Ok(observacao);
        }

        // PUT: api/Observacaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutObservacao(int id, Observacao observacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != observacao.Id)
            {
                return BadRequest();
            }

            db.Entry(observacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObservacaoExists(id))
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

        // POST: api/Observacaos
        [ResponseType(typeof(Observacao))]
        public IHttpActionResult PostObservacao(Observacao observacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Observacaos.Add(observacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = observacao.Id }, observacao);
        }

        // DELETE: api/Observacaos/5
        [ResponseType(typeof(Observacao))]
        public IHttpActionResult DeleteObservacao(int id)
        {
            Observacao observacao = db.Observacaos.Find(id);
            if (observacao == null)
            {
                return NotFound();
            }

            db.Observacaos.Remove(observacao);
            db.SaveChanges();

            return Ok(observacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObservacaoExists(int id)
        {
            return db.Observacaos.Count(e => e.Id == id) > 0;
        }
    }
}