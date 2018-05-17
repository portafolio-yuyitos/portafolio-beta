using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models
{
    public class DetalleBoleta
    {
        public int IdDetalle { get; set; }
        public int CantidadProducto { get; set; }
        public int IdProducto { get; set; }
        public int IdBoleta { get; set; }
    }
}