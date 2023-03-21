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
using WebApplicationEnsayo.Models;

namespace WebApplicationEnsayo
{
    public class DatosController : ApiController
    {
        private Base_PruebasEntities db = new Base_PruebasEntities();

        // GET: api/Datos
        public IQueryable<Datos> GetDatos()
        {
            return db.Datos;
        }

        // GET: api/Datos/5
        [ResponseType(typeof(Datos))]
        public IHttpActionResult GetDatos(int id)
        {
            Datos datos = db.Datos.Find(id);
            if (datos == null)
            {
                return NotFound();
            }

            return Ok(datos);
        }

        // PUT: api/Datos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDatos(int id, Datos datos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != datos.id)
            {
                return BadRequest();
            }

            db.Entry(datos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatosExists(id))
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

        // POST: api/Datos
        [ResponseType(typeof(Datos))]
        public IHttpActionResult PostDatos(Datos datos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Datos.Add(datos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = datos.id }, datos);
        }

        // DELETE: api/Datos/5
        [ResponseType(typeof(Datos))]
        public IHttpActionResult DeleteDatos(int id)
        {
            Datos datos = db.Datos.Find(id);
            if (datos == null)
            {
                return NotFound();
            }

            db.Datos.Remove(datos);
            db.SaveChanges();

            return Ok(datos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DatosExists(int id)
        {
            return db.Datos.Count(e => e.id == id) > 0;
        }
    }
}