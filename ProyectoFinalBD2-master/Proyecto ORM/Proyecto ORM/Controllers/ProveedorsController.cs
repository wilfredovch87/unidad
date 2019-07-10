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
using Proyecto_ORM.Models;

namespace Proyecto_ORM.Controllers
{
    public class ProveedorsController : ApiController
    {
        private Proyecto_ORMContext db = new Proyecto_ORMContext();

        // GET: api/Proveedors
        public IQueryable<Proveedor> GetProveedors()
        {
            return db.Proveedors;
        }

        // GET: api/Proveedors/5
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult GetProveedor(string id)
        {
            Proveedor proveedor = db.Proveedors.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        // PUT: api/Proveedors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProveedor(string id, Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedor.Dni)
            {
                return BadRequest();
            }

            db.Entry(proveedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedors
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult PostProveedor(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proveedors.Add(proveedor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProveedorExists(proveedor.Dni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = proveedor.Dni }, proveedor);
        }

        // DELETE: api/Proveedors/5
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult DeleteProveedor(string id)
        {
            Proveedor proveedor = db.Proveedors.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            db.Proveedors.Remove(proveedor);
            db.SaveChanges();

            return Ok(proveedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProveedorExists(string id)
        {
            return db.Proveedors.Count(e => e.Dni == id) > 0;
        }
    }
}