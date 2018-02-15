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
using WsEventosUG.Models;

namespace WsEventosUG.Controllers
{
    public class PreferenciasController : ApiController
    {
        private dbEventosUGEntities db = new dbEventosUGEntities();

        // GET: api/Preferencias
        public IQueryable<Preferencia> GetPreferencia()
        {
            return db.Preferencia;
        }

        // GET: api/Preferencias/5
        [ResponseType(typeof(Preferencia))]
        public IHttpActionResult GetPreferencia(int id)
        {
            Preferencia preferencia = db.Preferencia.Find(id);
            if (preferencia == null)
            {
                return NotFound();
            }

            return Ok(preferencia);
        }

        // PUT: api/Preferencias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPreferencia(int id, Preferencia preferencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preferencia.id_preferencia)
            {
                return BadRequest();
            }

            db.Entry(preferencia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferenciaExists(id))
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

        // POST: api/Preferencias
        [ResponseType(typeof(Preferencia))]
        public IHttpActionResult PostPreferencia(Preferencia preferencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Preferencia.Add(preferencia);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PreferenciaExists(preferencia.id_preferencia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = preferencia.id_preferencia }, preferencia);
        }

        // DELETE: api/Preferencias/5
        [ResponseType(typeof(Preferencia))]
        public IHttpActionResult DeletePreferencia(int id)
        {
            Preferencia preferencia = db.Preferencia.Find(id);
            if (preferencia == null)
            {
                return NotFound();
            }

            db.Preferencia.Remove(preferencia);
            db.SaveChanges();

            return Ok(preferencia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreferenciaExists(int id)
        {
            return db.Preferencia.Count(e => e.id_preferencia == id) > 0;
        }
    }
}