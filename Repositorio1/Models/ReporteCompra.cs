
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositorio1.Models
{
    public class ReporteCompra
    {
        public string nombreCliente { get; set; }
        public string documentoCliente { get; set; }
        public string emailCliente { get; set; }
        public DateTime fechaCompra { get; set; }
        public int totalCompra { get; set; }
    }
}