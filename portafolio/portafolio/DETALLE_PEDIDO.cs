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
    
    public partial class DETALLE_PEDIDO
    {
        public decimal NUMERO_PEDIDO { get; set; }
        public decimal NUMERO_DETALLE { get; set; }
        public decimal CANTIDAD_PRODUCTO { get; set; }
        public Nullable<decimal> PRECIO_PRODUCTO { get; set; }
        public decimal ID_PRODUCTO { get; set; }
    
        public virtual PRODUCTO PRODUCTO { get; set; }
        public virtual PEDIDO PEDIDO { get; set; }
    }
}