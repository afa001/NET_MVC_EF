using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAplicacion.Models;

namespace WebAplicacion.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            IEnumerable<Usuarios> usuarios;
            HttpResponseMessage response = ServicioGlobal.webAppClient.GetAsync("Usuarios").Result;
            usuarios = response.Content.ReadAsAsync<IEnumerable<Usuarios>>().Result;      
            
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuarios usuario)
        {
            try
            {
                HttpResponseMessage response = ServicioGlobal.webAppClient.PostAsJsonAsync("Usuarios",usuario).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int  id)
        {
            HttpResponseMessage response = ServicioGlobal.webAppClient.GetAsync("Usuarios/" + id ).Result;
            return View(response.Content.ReadAsAsync<Usuarios>().Result);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuarios usuario)
        {
            try
            {
                HttpResponseMessage response = ServicioGlobal.webAppClient.PutAsJsonAsync("Usuarios/" + id, usuario).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = ServicioGlobal.webAppClient.GetAsync("Usuarios/" + id).Result;

            return View(response.Content.ReadAsAsync<Usuarios>().Result);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Usuarios usuario)
        {
            try
            {
                HttpResponseMessage response = ServicioGlobal.webAppClient.DeleteAsync("Usuarios/" + id).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
