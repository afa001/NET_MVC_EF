using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAplicacion.Models;

namespace WebAplicacion.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult Index()
        {
            IEnumerable<Pedidos> pedidos;
            HttpResponseMessage response = ServicioGlobal.webAppClient.GetAsync("Pedidos").Result;
            pedidos = response.Content.ReadAsAsync<IEnumerable<Pedidos>>().Result;

            return View(pedidos);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            IEnumerable<Usuarios> usuarios;
            HttpResponseMessage responseUsuarios = ServicioGlobal.webAppClient.GetAsync("Usuarios").Result;
            usuarios = responseUsuarios.Content.ReadAsAsync<IEnumerable<Usuarios>>().Result;

            ViewBag.UsuID = new SelectList(usuarios, "UsuID", "UsuNombre");

            IEnumerable<Productos> productos;
            HttpResponseMessage responseProductos = ServicioGlobal.webAppClient.GetAsync("Productos").Result;
            productos = responseProductos.Content.ReadAsAsync<IEnumerable<Productos>>().Result;

            ViewBag.ProID = new SelectList(productos, "ProID", "ProDesc");

            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        public ActionResult Create(Pedidos pedido)
        {
            try
            {
                HttpResponseMessage response = ServicioGlobal.webAppClient.PostAsJsonAsync("Pedidos", pedido).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Usuarios> usuarios;
            HttpResponseMessage responseUsuarios = ServicioGlobal.webAppClient.GetAsync("Usuarios").Result;
            usuarios = responseUsuarios.Content.ReadAsAsync<IEnumerable<Usuarios>>().Result;

            ViewBag.UsuID = new SelectList(usuarios, "UsuID", "UsuNombre");

            IEnumerable<Productos> productos;
            HttpResponseMessage responseProductos = ServicioGlobal.webAppClient.GetAsync("Productos").Result;
            productos = responseProductos.Content.ReadAsAsync<IEnumerable<Productos>>().Result;

            ViewBag.ProID = new SelectList(productos, "ProID", "ProDesc");

            HttpResponseMessage responsePedido = ServicioGlobal.webAppClient.GetAsync("Pedidos/" + id).Result;

            return View(responsePedido.Content.ReadAsAsync<Pedidos>().Result);
        }

        // POST: Pedidos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pedidos pedido)
        {
            try
            {
                HttpResponseMessage response = ServicioGlobal.webAppClient.PutAsJsonAsync("Pedidos/" + id, pedido).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = ServicioGlobal.webAppClient.GetAsync("Pedidos/" + id).Result;

            return View(response.Content.ReadAsAsync<Pedidos>().Result);
        }

        // POST: Pedidos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Pedidos pedido)
        {
            try
            {
                HttpResponseMessage response = ServicioGlobal.webAppClient.DeleteAsync("Pedidos/" + id).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
