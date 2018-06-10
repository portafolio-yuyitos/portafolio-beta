using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models.ViewModels
{
    public class ProveedorProducto_I
    {
        public int IdProveedor { get; set; }
        public string RutProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string Giro { get; set; }
        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public int PrecioVenta { get; set; }
        public int Stock { get; set; }
        
    }
}