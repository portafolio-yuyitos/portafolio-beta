using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string RutEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public int Fono { get; set; }
        public string Email { get; set; }
        public string Giro { get; set; }
    }
}