using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models
{
    public class Pedidos
    {
        public int PedID { get; set; }
        public int PedUsu { get; set; }
        public int PedPro { get; set; }
        public decimal PedVrUnit { get; set; }
        public double PedCant { get; set; }
        public decimal PedSubtot { get; set; }
        public double PedIVA { get; set; }
        public decimal PedTotal { get; set; }
    }
}