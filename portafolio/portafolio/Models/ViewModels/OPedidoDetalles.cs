using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models.ViewModels
{
    public class OPedidoDetalles
    {
        public Pedido Encabezado { get; set; }
        public List<DetallePedido> Detalles { get; set; }
    }
}