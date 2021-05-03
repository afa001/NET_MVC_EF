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
    public class PedidosController : ApiController
    {
        private dbCarvajalEntities db = new dbCarvajalEntities();

        // GET: api/Pedidos
        public IQueryable<Pedidos> GetPedidos()
        {
            return db.Pedidos;
        }

        // GET: api/Pedidos/5
        [ResponseType(typeof(Pedidos))]
        public async Task<IHttpActionResult> GetPedidos(int id)
        {
            Pedidos pedidos = await db.Pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        // PUT: api/Pedidos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPedidos(int id, Pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidos.PedID)
            {
                return BadRequest();
            }

            db.Entry(pedidos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidosExists(id))
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

        // POST: api/Pedidos
        [ResponseType(typeof(Pedidos))]
        public async Task<IHttpActionResult> PostPedidos(Pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedidos.Add(pedidos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pedidos.PedID }, pedidos);
        }

        // DELETE: api/Pedidos/5
        [ResponseType(typeof(Pedidos))]
        public async Task<IHttpActionResult> DeletePedidos(int id)
        {
            Pedidos pedidos = await db.Pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            db.Pedidos.Remove(pedidos);
            await db.SaveChangesAsync();

            return Ok(pedidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidosExists(int id)
        {
            return db.Pedidos.Count(e => e.PedID == id) > 0;
        }
    }
}