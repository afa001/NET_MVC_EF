using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models
{
    public class Productos
    {
        public int ProID { get; set; }
        public string ProDesc { get; set; }
        public Nullable<decimal> ProValor { get; set; }
    }
}