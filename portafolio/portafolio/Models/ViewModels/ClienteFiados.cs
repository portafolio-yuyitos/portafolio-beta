using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models.ViewModels
{
    public class ClienteFiados
    {
        public Cliente Cliente { get; set; }
        public List<Fiado> ListaFiados { get; set; }
    }
}