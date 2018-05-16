using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models
{
    public class Fiado
    {
        public int IdFiado { get; set; }
        public int MontoSolicitado { get; set; }
        public int MontoPagado { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaPago { get; set; }
        public string EstadoPago { get; set; }
        public int IdCliente { get; set; }
        public int IdBoleta { get; set; }
    }
}