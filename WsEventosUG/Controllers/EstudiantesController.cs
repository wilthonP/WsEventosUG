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
    public class EstudiantesController : ApiController
    {
        private dbEventosUGEntities db = new dbEventosUGEntities();

        // GET: api/Estudiantes
        public IQueryable<Estudiantes> GetEstudiantes()
        {
            return db.Estudiantes;
        }

        // GET: api/Estudiantes/5
        [ResponseType(typeof(Estudiantes))]
        public IHttpActionResult GetEstudiantes(int id)
        {
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return Ok(estudiantes);
        }

        // PUT: api/Estudiantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstudiantes(int id, Estudiantes estudiantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudiantes.identificacion)
            {
                return BadRequest();
            }

            db.Entry(estudiantes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudiantesExists(id))
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

        // POST: api/Estudiantes
        [ResponseType(typeof(Estudiantes))]
        public IHttpActionResult PostEstudiantes(Estudiantes estudiantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estudiantes.Add(estudiantes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EstudiantesExists(estudiantes.identificacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = estudiantes.identificacion }, estudiantes);
        }

        // DELETE: api/Estudiantes/5
        [ResponseType(typeof(Estudiantes))]
        public IHttpActionResult DeleteEstudiantes(int id)
        {
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            db.Estudiantes.Remove(estudiantes);
            db.SaveChanges();

            return Ok(estudiantes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstudiantesExists(int id)
        {
            return db.Estudiantes.Count(e => e.identificacion == id) > 0;
        }
    }
}