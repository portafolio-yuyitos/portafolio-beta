﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BOLETA> BOLETA { get; set; }
        public DbSet<CLIENTE> CLIENTE { get; set; }
        public DbSet<DETALLE_BOLETA> DETALLE_BOLETA { get; set; }
        public DbSet<EMPRESA> EMPRESA { get; set; }
        public DbSet<FIADO> FIADO { get; set; }
        public DbSet<FUNCIONALIDAD> FUNCIONALIDAD { get; set; }
        public DbSet<PEDIDO> PEDIDO { get; set; }
        public DbSet<PRODUCTO> PRODUCTO { get; set; }
        public DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        public DbSet<RECEPCION> RECEPCION { get; set; }
        public DbSet<ROL> ROL { get; set; }
        public DbSet<TIPO_MONEDA> TIPO_MONEDA { get; set; }
        public DbSet<TIPO_PRODUCTO> TIPO_PRODUCTO { get; set; }
        public DbSet<USUARIO> USUARIO { get; set; }
    
        public virtual int SP_S_VALIDAUSUARIO(string uSU, string cON, ObjectParameter eXISTE)
        {
            var uSUParameter = uSU != null ?
                new ObjectParameter("USU", uSU) :
                new ObjectParameter("USU", typeof(string));
    
            var cONParameter = cON != null ?
                new ObjectParameter("CON", cON) :
                new ObjectParameter("CON", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_S_VALIDAUSUARIO", uSUParameter, cONParameter, eXISTE);
        }
    
        public virtual int SP_I_CLIENTE(string rUT_CLIENTE, string nOMBRE_CLIENTE, Nullable<decimal> aUTORIZADO_FIADO)
        {
            var rUT_CLIENTEParameter = rUT_CLIENTE != null ?
                new ObjectParameter("RUT_CLIENTE", rUT_CLIENTE) :
                new ObjectParameter("RUT_CLIENTE", typeof(string));
    
            var nOMBRE_CLIENTEParameter = nOMBRE_CLIENTE != null ?
                new ObjectParameter("NOMBRE_CLIENTE", nOMBRE_CLIENTE) :
                new ObjectParameter("NOMBRE_CLIENTE", typeof(string));
    
            var aUTORIZADO_FIADOParameter = aUTORIZADO_FIADO.HasValue ?
                new ObjectParameter("AUTORIZADO_FIADO", aUTORIZADO_FIADO) :
                new ObjectParameter("AUTORIZADO_FIADO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_I_CLIENTE", rUT_CLIENTEParameter, nOMBRE_CLIENTEParameter, aUTORIZADO_FIADOParameter);
        }
    
        public virtual int SP_I_PROVEEDOR(string rUT_PROVEEDOR, string rAZON_SOCIAL, Nullable<decimal> fONO, string eMAIL, string gIRO)
        {
            var rUT_PROVEEDORParameter = rUT_PROVEEDOR != null ?
                new ObjectParameter("RUT_PROVEEDOR", rUT_PROVEEDOR) :
                new ObjectParameter("RUT_PROVEEDOR", typeof(string));
    
            var rAZON_SOCIALParameter = rAZON_SOCIAL != null ?
                new ObjectParameter("RAZON_SOCIAL", rAZON_SOCIAL) :
                new ObjectParameter("RAZON_SOCIAL", typeof(string));
    
            var fONOParameter = fONO.HasValue ?
                new ObjectParameter("FONO", fONO) :
                new ObjectParameter("FONO", typeof(decimal));
    
            var eMAILParameter = eMAIL != null ?
                new ObjectParameter("EMAIL", eMAIL) :
                new ObjectParameter("EMAIL", typeof(string));
    
            var gIROParameter = gIRO != null ?
                new ObjectParameter("GIRO", gIRO) :
                new ObjectParameter("GIRO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_I_PROVEEDOR", rUT_PROVEEDORParameter, rAZON_SOCIALParameter, fONOParameter, eMAILParameter, gIROParameter);
        }
    
        public virtual int SP_D_CLIENTE(string rUT_CLIENTE_D)
        {
            var rUT_CLIENTE_DParameter = rUT_CLIENTE_D != null ?
                new ObjectParameter("RUT_CLIENTE_D", rUT_CLIENTE_D) :
                new ObjectParameter("RUT_CLIENTE_D", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_D_CLIENTE", rUT_CLIENTE_DParameter);
        }
    
        public virtual int SP_D_PROVEEDOR(string rUT_PROVEEDOR_D)
        {
            var rUT_PROVEEDOR_DParameter = rUT_PROVEEDOR_D != null ?
                new ObjectParameter("RUT_PROVEEDOR_D", rUT_PROVEEDOR_D) :
                new ObjectParameter("RUT_PROVEEDOR_D", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_D_PROVEEDOR", rUT_PROVEEDOR_DParameter);
        }
    
        public virtual int SP_U_PROVEEDOR(string v_RUT_PROVEEDOR, string v_RAZON_SOCIAL, Nullable<decimal> v_FONO, string v_EMAIL, string v_GIRO)
        {
            var v_RUT_PROVEEDORParameter = v_RUT_PROVEEDOR != null ?
                new ObjectParameter("V_RUT_PROVEEDOR", v_RUT_PROVEEDOR) :
                new ObjectParameter("V_RUT_PROVEEDOR", typeof(string));
    
            var v_RAZON_SOCIALParameter = v_RAZON_SOCIAL != null ?
                new ObjectParameter("V_RAZON_SOCIAL", v_RAZON_SOCIAL) :
                new ObjectParameter("V_RAZON_SOCIAL", typeof(string));
    
            var v_FONOParameter = v_FONO.HasValue ?
                new ObjectParameter("V_FONO", v_FONO) :
                new ObjectParameter("V_FONO", typeof(decimal));
    
            var v_EMAILParameter = v_EMAIL != null ?
                new ObjectParameter("V_EMAIL", v_EMAIL) :
                new ObjectParameter("V_EMAIL", typeof(string));
    
            var v_GIROParameter = v_GIRO != null ?
                new ObjectParameter("V_GIRO", v_GIRO) :
                new ObjectParameter("V_GIRO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_U_PROVEEDOR", v_RUT_PROVEEDORParameter, v_RAZON_SOCIALParameter, v_FONOParameter, v_EMAILParameter, v_GIROParameter);
        }
    
        public virtual int SP_U_CLIENTE(string v_RUT_CLIENTE, string v_NOMBRE)
        {
            var v_RUT_CLIENTEParameter = v_RUT_CLIENTE != null ?
                new ObjectParameter("V_RUT_CLIENTE", v_RUT_CLIENTE) :
                new ObjectParameter("V_RUT_CLIENTE", typeof(string));
    
            var v_NOMBREParameter = v_NOMBRE != null ?
                new ObjectParameter("V_NOMBRE", v_NOMBRE) :
                new ObjectParameter("V_NOMBRE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_U_CLIENTE", v_RUT_CLIENTEParameter, v_NOMBREParameter);
        }
    
        public virtual int SP_D_CLIENTE1(string rUT_CLIENTE_D)
        {
            var rUT_CLIENTE_DParameter = rUT_CLIENTE_D != null ?
                new ObjectParameter("RUT_CLIENTE_D", rUT_CLIENTE_D) :
                new ObjectParameter("RUT_CLIENTE_D", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_D_CLIENTE1", rUT_CLIENTE_DParameter);
        }
    
        public virtual int SP_D_PROVEEDOR1(string rUT_PROVEEDOR_D)
        {
            var rUT_PROVEEDOR_DParameter = rUT_PROVEEDOR_D != null ?
                new ObjectParameter("RUT_PROVEEDOR_D", rUT_PROVEEDOR_D) :
                new ObjectParameter("RUT_PROVEEDOR_D", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_D_PROVEEDOR1", rUT_PROVEEDOR_DParameter);
        }
    
        public virtual int SP_U_FIADOR(string rUT)
        {
            var rUTParameter = rUT != null ?
                new ObjectParameter("RUT", rUT) :
                new ObjectParameter("RUT", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_U_FIADOR", rUTParameter);
        }
    
        public virtual int SP_U_PROVEEDOR1(string v_RUT_PROVEEDOR, string v_RAZON_SOCIAL, Nullable<decimal> v_FONO, string v_EMAIL, string v_GIRO)
        {
            var v_RUT_PROVEEDORParameter = v_RUT_PROVEEDOR != null ?
                new ObjectParameter("V_RUT_PROVEEDOR", v_RUT_PROVEEDOR) :
                new ObjectParameter("V_RUT_PROVEEDOR", typeof(string));
    
            var v_RAZON_SOCIALParameter = v_RAZON_SOCIAL != null ?
                new ObjectParameter("V_RAZON_SOCIAL", v_RAZON_SOCIAL) :
                new ObjectParameter("V_RAZON_SOCIAL", typeof(string));
    
            var v_FONOParameter = v_FONO.HasValue ?
                new ObjectParameter("V_FONO", v_FONO) :
                new ObjectParameter("V_FONO", typeof(decimal));
    
            var v_EMAILParameter = v_EMAIL != null ?
                new ObjectParameter("V_EMAIL", v_EMAIL) :
                new ObjectParameter("V_EMAIL", typeof(string));
    
            var v_GIROParameter = v_GIRO != null ?
                new ObjectParameter("V_GIRO", v_GIRO) :
                new ObjectParameter("V_GIRO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_U_PROVEEDOR1", v_RUT_PROVEEDORParameter, v_RAZON_SOCIALParameter, v_FONOParameter, v_EMAILParameter, v_GIROParameter);
        }
    }
}
