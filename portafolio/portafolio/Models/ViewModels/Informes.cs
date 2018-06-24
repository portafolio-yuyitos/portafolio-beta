using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models.ViewModels
{
    public class Informes
    {
        public List<Cliente> InformeCliente { get; set; }
        public List<ClienteFiados_I> InformeClienteFiados { get; set; }
        public List<ClientesGasto> InformClientesGasto { get; set; }
        public List<ProveedorProducto_I> InformeProveedorProducto { get; set; }
        public List<PeoresFiadores_I> InformePeoresFiadores { get; set; }
        public List<Boleta> InformeBoletas30Dias { get; set; }
        public List<ProductoPorcentajeStock> InformeStockProductos { get; set; }
    }
}