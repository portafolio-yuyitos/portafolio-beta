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
    
    public partial class USUARIO
    {
        public USUARIO()
        {
            this.RECEPCION = new HashSet<RECEPCION>();
            this.PEDIDO = new HashSet<PEDIDO>();
        }
    
        public decimal ID_USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string CLAVE { get; set; }
        public decimal ID_ROL { get; set; }
    
        public virtual ICollection<RECEPCION> RECEPCION { get; set; }
        public virtual ROL ROL { get; set; }
        public virtual ICollection<PEDIDO> PEDIDO { get; set; }
    }
}
