using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models
{
    public class Boleta
    {
        public int NumeroBoleta { get; set; }
        public int Fiado { get; set; }
        public string TipoPago { get; set; }
        public int TotalBoleta { get; set; }
        public DateTime FechaBoleta { get; set; }
        public int IdCliente { get; set; }
    }
}