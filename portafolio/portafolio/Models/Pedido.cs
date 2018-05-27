using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models
{
    public class Pedido
    {
        public int NumeroPedido { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }
    }
}