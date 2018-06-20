using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models
{
    public class DetallePedido
    {
        public int NumeroPedido { get; set; }
        public int NumeroDetalle { get; set; }
        public int IdProducto { get; set; }
        public int CantidadProducto { get; set; }
        public int PrecioProducto { get; set; }
        public int IdProveedor { get; set; }
        public string NombreProducto { get; set; }
        //public int Estado { get; set; }
    }
}