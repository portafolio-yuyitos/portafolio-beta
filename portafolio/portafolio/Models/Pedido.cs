using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models
{
    public class Pedido
    {
        public int NumeroPedido { get; set; }
        public int CantidadSolicitada { get; set; }
        public int IdProveedor { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
    }
}