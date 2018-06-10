using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models.ViewModels
{
    public class PeoresFiadores_I
    {
        public int IdCliente { get; set; }
        public string RutCliente { get; set; }
        public string Nombre { get; set; }
        public int IdFiado { get; set; }
        public int MontoAdeudado { get; set; }
    }
}