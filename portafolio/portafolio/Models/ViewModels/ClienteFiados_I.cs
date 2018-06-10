using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models.ViewModels
{
    public class ClienteFiados_I
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public int MontoSolicitado { get; set; }
        public int MontoPagado { get; set; }
        public DateTime FechaCompra { get; set; }
        public string EstadoPago { get; set; }
        public int IdFiado { get; set; }
    }
}