using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models.ViewModels
{
    public class Bienvenida
    {
        public List<Boleta> Ultimas5Boletas { get; set; }
        public List<ClienteFiados_I> PeoresPagadores { get; set; }
        public List<ProductoPorcentajeStock> ProductosPocoStock { get; set; }
    }
}