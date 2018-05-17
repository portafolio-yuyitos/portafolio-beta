using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models
{
    public class Recepcion
    {
        public int NumeroRecepcion { get; set; }
        public int CantidadRecibida { get; set; }
        public int IdProveedor { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
    }
}