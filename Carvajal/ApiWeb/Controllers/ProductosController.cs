using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiWeb.Models;

namespace ApiWeb.Controllers
{
    public class ProductosController : ApiController
    {
        private dbCarvajalEntities db = new dbCarvajalEntities();

        // GET: api/Productos
        public IQueryable<Productos> GetProductos()
        {
            return db.Productos;
        }

        // GET: api/Productos/5
        [ResponseType(typeof(Productos))]
        public async Task<IHttpActionResult> GetProductos(int id)
        {
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        // PUT: api/Productos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductos(int id, Productos productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productos.ProID)
            {
                return BadRequest();
            }

            db.Entry(productos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
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

        // POST: api/Productos
        [ResponseType(typeof(Productos))]
        public async Task<IHttpActionResult> PostProductos(Productos productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Productos.Add(productos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductosExists(productos.ProID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productos.ProID }, productos);
        }

        // DELETE: api/Productos/5
        [ResponseType(typeof(Productos))]
        public async Task<IHttpActionResult> DeleteProductos(int id)
        {
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            db.Productos.Remove(productos);
            await db.SaveChangesAsync();

            return Ok(productos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductosExists(int id)
        {
            return db.Productos.Count(e => e.ProID == id) > 0;
        }
    }
}