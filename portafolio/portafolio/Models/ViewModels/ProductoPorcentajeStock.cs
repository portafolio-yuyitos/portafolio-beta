﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models.ViewModels
{
    public class ProductoPorcentajeStock
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int PrecioVenta { get; set; }
        public string UnidadMedida { get; set; }
        public DateTime FechaVentimiento { get; set; }
        public int PrecioCompra { get; set; }
        public int StockCritico { get; set; }
        public int IdProveedor { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdTipoMoneda { get; set; }
        public int Stock { get; set; }
        public int PorcentajeStock { get; set; }
        public string CodigoBarra { get; set; }
    }
}