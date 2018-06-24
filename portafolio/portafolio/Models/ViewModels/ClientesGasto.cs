using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models.ViewModels
{
    public class ClientesGasto
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public int TotalCompras { get; set; }
        public DateTime FechUltiCompra { get; set; }
        
    }
}