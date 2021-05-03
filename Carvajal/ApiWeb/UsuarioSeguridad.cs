using ApiWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWeb
{
    public class UsuarioSeguridad
    {
        public static bool Login(string nombreUsuario, string clave)
        {
            using (dbCarvajalEntities db = new dbCarvajalEntities())
            {
                return db.Usuarios.Any(usuario => usuario.UsuNombre.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) && usuario.UsuPass == clave);
            }
        }
    }
}