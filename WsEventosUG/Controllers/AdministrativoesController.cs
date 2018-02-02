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
    public class AdministrativoesController : ApiController
    {
        private dbEventosUGEntities db = new dbEventosUGEntities();

        // GET: api/Administrativoes
        public IQueryable<Administrativo> GetAdministrativo()
        {
            return db.Administrativo;
        }

        // GET: api/Administrativoes/5
        [ResponseType(typeof(Administrativo))]
        public IHttpActionResult GetAdministrativo(int id)
        {
            Administrativo administrativo = db.Administrativo.Find(id);
            if (administrativo == null)
            {
                return NotFound();
            }

            return Ok(administrativo);
        }

        // PUT: api/Administrativoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdministrativo(int id, Administrativo administrativo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrativo.id_administrativo)
            {
                return BadRequest();
            }

            db.Entry(administrativo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrativoExists(id))
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

        // POST: api/Administrativoes
        [ResponseType(typeof(Administrativo))]
        public IHttpActionResult PostAdministrativo(Administrativo administrativo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Administrativo.Add(administrativo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdministrativoExists(administrativo.id_administrativo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = administrativo.id_administrativo }, administrativo);
        }

        // DELETE: api/Administrativoes/5
        [ResponseType(typeof(Administrativo))]
        public IHttpActionResult DeleteAdministrativo(int id)
        {
            Administrativo administrativo = db.Administrativo.Find(id);
            if (administrativo == null)
            {
                return NotFound();
            }

            db.Administrativo.Remove(administrativo);
            db.SaveChanges();

            return Ok(administrativo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministrativoExists(int id)
        {
            return db.Administrativo.Count(e => e.id_administrativo == id) > 0;
        }
    }
}