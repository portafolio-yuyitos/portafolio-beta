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
    
    public partial class CLIENTE
    {
        public CLIENTE()
        {
            this.BOLETA = new HashSet<BOLETA>();
            this.FIADO = new HashSet<FIADO>();
        }
    
        public decimal ID_CLIENTE { get; set; }
        public string RUT_CLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public short AUTORIZADO_FIADO { get; set; }
        public Nullable<short> ESTADO { get; set; }
    
        public virtual ICollection<BOLETA> BOLETA { get; set; }
        public virtual ICollection<FIADO> FIADO { get; set; }
    }
}
