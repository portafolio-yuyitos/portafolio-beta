//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace portafolio
{
    using System;
    using System.Collections.Generic;
    
    public partial class PEDIDO
    {
        public PEDIDO()
        {
            this.DETALLE_PEDIDO = new HashSet<DETALLE_PEDIDO>();
        }
    
        public decimal NUMERO_PEDIDO { get; set; }
        public decimal ID_PROVEEDOR { get; set; }
        public decimal ID_USUARIO { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
        public decimal ISANULADO { get; set; }
        public decimal ISENVIADO { get; set; }
        public decimal ESTADO { get; set; }
    
        public virtual ICollection<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }
        public virtual PROVEEDOR PROVEEDOR { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
