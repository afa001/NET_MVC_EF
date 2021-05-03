using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAplicacion.Models;

namespace WebAplicacion.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            IEnumerable<Productos> productos;
            HttpResponseMessage response = ServicioGlobal.webAppClient.GetAsync("Productos").Result;
            productos = response.Content.ReadAsAsync<IEnumerable<Productos>>().Result;

            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(Productos producto)
        {
            try
            {
                HttpResponseMessage response = ServicioGlobal.webAppClient.PostAsJsonAsync("Productos", producto).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = ServicioGlobal.webAppClient.GetAsync("Productos/" + id).Result;
            return View(response.Content.ReadAsAsync<Productos>().Result);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Productos producto)
        {
            try
            {
                HttpResponseMessage response = ServicioGlobal.webAppClient.PutAsJsonAsync("Productos/" + id, producto).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = ServicioGlobal.webAppClient.GetAsync("Productos/" + id).Result;

            return View(response.Content.ReadAsAsync<Productos>().Result);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Productos producto)
        {
            try
            {
                HttpResponseMessage response = ServicioGlobal.webAppClient.DeleteAsync("Productos/" + id).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
