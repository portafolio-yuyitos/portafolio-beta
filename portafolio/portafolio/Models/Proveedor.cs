using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models
{
    public class Proveedor
    {
        public int IdProveedor
        {
            get; set;
        }

        public string RutProveedor
        {
            get; set;
        }

        public string RazonSocial
        {
            get; set;
        }

        public int Fono
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string Giro
        {
            get; set;
        }
    }
}