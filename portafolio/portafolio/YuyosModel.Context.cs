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
    
    public partial class YuyosEntities : DbContext
    {
        public YuyosEntities()
            : base("name=YuyosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BOLETA> BOLETA { get; set; }
        public DbSet<CLIENTE> CLIENTE { get; set; }
        public DbSet<DETALLE_BOLETA> DETALLE_BOLETA { get; set; }
        public DbSet<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }
        public DbSet<EMPRESA> EMPRESA { get; set; }
        public DbSet<FIADO> FIADO { get; set; }
        public DbSet<FUNCIONALIDAD> FUNCIONALIDAD { get; set; }
        public DbSet<PRODUCTO> PRODUCTO { get; set; }
        public DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        public DbSet<RECEPCION> RECEPCION { get; set; }
        public DbSet<ROL> ROL { get; set; }
        public DbSet<TIPO_MONEDA> TIPO_MONEDA { get; set; }
        public DbSet<TIPO_PRODUCTO> TIPO_PRODUCTO { get; set; }
        public DbSet<USUARIO> USUARIO { get; set; }
        public DbSet<PEDIDO> PEDIDO { get; set; }
    
        public virtual int SP_D_BOLETA(string nUMERO_BOLETA)
        {
            var nUMERO_BOLETAParameter = nUMERO_BOLETA != null ?
                new ObjectParameter("NUMERO_BOLETA", nUMERO_BOLETA) :
                new ObjectParameter("NUMERO_BOLETA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_D_BOLETA", nUMERO_BOLETAParameter);
        }
    
        public virtual int SP_D_CLIENTE(string rUT_CLIENTE_D)
        {
            var rUT_CLIENTE_DParameter = rUT_CLIENTE_D != null ?
                new ObjectParameter("RUT_CLIENTE_D", rUT_CLIENTE_D) :
                new ObjectParameter("RUT_CLIENTE_D", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_D_CLIENTE", rUT_CLIENTE_DParameter);
        }
    
        public virtual int SP_D_DETALLE_BOLETA(string iD_DETALLE)
        {
            var iD_DETALLEParameter = iD_DETALLE != null ?
                new ObjectParameter("ID_DETALLE", iD_DETALLE) :
                new ObjectParameter("ID_DETALLE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_D_DETALLE_BOLETA", iD_DETALLEParameter);
        }
    
        public virtual int SP_D_DETALLE_PEDIDO(Nullable<decimal> v_NUMERO_PEDIDO)
        {
            var v_NUMERO_PEDIDOParameter = v_NUMERO_PEDIDO.HasValue ?
                new ObjectParameter("V_NUMERO_PEDIDO", v_NUMERO_PEDIDO) :
                new ObjectParameter("V_NUMERO_PEDIDO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_D_DETALLE_PEDIDO", v_NUMERO_PEDIDOParameter);
        }
    
        public virtual int SP_D_PEDIDO(Nullable<decimal> v_NUMERO_PEDIDO)
        {
            var v_NUMERO_PEDIDOParameter = v_NUMERO_PEDIDO.HasValue ?
                new ObjectParameter("V_NUMERO_PEDIDO", v_NUMERO_PEDIDO) :
                new ObjectParameter("V_NUMERO_PEDIDO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_D_PEDIDO", v_NUMERO_PEDIDOParameter);
        }
    
        public virtual int SP_D_PROVEEDOR(string rUT_PROVEEDOR_D)
        {
            var rUT_PROVEEDOR_DParameter = rUT_PROVEEDOR_D != null ?
                new ObjectParameter("RUT_PROVEEDOR_D", rUT_PROVEEDOR_D) :
                new ObjectParameter("RUT_PROVEEDOR_D", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_D_PROVEEDOR", rUT_PROVEEDOR_DParameter);
        }
    
        public virtual int SP_I_BOLETA(Nullable<decimal> v_FIADO, string v_TIPO_PAGO, Nullable<decimal> v_TOTAL_BOLETA, Nullable<System.DateTime> v_FECHA_BOLETA, Nullable<decimal> v_ID_CLIENTE)
        {
            var v_FIADOParameter = v_FIADO.HasValue ?
                new ObjectParameter("V_FIADO", v_FIADO) :
                new ObjectParameter("V_FIADO", typeof(decimal));
    
            var v_TIPO_PAGOParameter = v_TIPO_PAGO != null ?
                new ObjectParameter("V_TIPO_PAGO", v_TIPO_PAGO) :
                new ObjectParameter("V_TIPO_PAGO", typeof(string));
    
            var v_TOTAL_BOLETAParameter = v_TOTAL_BOLETA.HasValue ?
                new ObjectParameter("V_TOTAL_BOLETA", v_TOTAL_BOLETA) :
                new ObjectParameter("V_TOTAL_BOLETA", typeof(decimal));
    
            var v_FECHA_BOLETAParameter = v_FECHA_BOLETA.HasValue ?
                new ObjectParameter("V_FECHA_BOLETA", v_FECHA_BOLETA) :
                new ObjectParameter("V_FECHA_BOLETA", typeof(System.DateTime));
    
            var v_ID_CLIENTEParameter = v_ID_CLIENTE.HasValue ?
                new ObjectParameter("V_ID_CLIENTE", v_ID_CLIENTE) :
                new ObjectParameter("V_ID_CLIENTE", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_I_BOLETA", v_FIADOParameter, v_TIPO_PAGOParameter, v_TOTAL_BOLETAParameter, v_FECHA_BOLETAParameter, v_ID_CLIENTEParameter);
        }
    
        public virtual int SP_I_CLIENTE(string v_RUT_CLIENTE, string v_NOMBRE_CLIENTE, Nullable<decimal> v_AUTORIZADO_FIADO, ObjectParameter v_SALIDA)
        {
            var v_RUT_CLIENTEParameter = v_RUT_CLIENTE != null ?
                new ObjectParameter("V_RUT_CLIENTE", v_RUT_CLIENTE) :
                new ObjectParameter("V_RUT_CLIENTE", typeof(string));
    
            var v_NOMBRE_CLIENTEParameter = v_NOMBRE_CLIENTE != null ?
                new ObjectParameter("V_NOMBRE_CLIENTE", v_NOMBRE_CLIENTE) :
                new ObjectParameter("V_NOMBRE_CLIENTE", typeof(string));
    
            var v_AUTORIZADO_FIADOParameter = v_AUTORIZADO_FIADO.HasValue ?
                new ObjectParameter("V_AUTORIZADO_FIADO", v_AUTORIZADO_FIADO) :
                new ObjectParameter("V_AUTORIZADO_FIADO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_I_CLIENTE", v_RUT_CLIENTEParameter, v_NOMBRE_CLIENTEParameter, v_AUTORIZADO_FIADOParameter, v_SALIDA);
        }
    
        public virtual int SP_I_DETALLE_BOLETA(Nullable<decimal> v_CANTIDAD_PRODUCTO, Nullable<decimal> v_ID_PRODUCTO, Nullable<decimal> v_ID_BOLETA)
        {
            var v_CANTIDAD_PRODUCTOParameter = v_CANTIDAD_PRODUCTO.HasValue ?
                new ObjectParameter("V_CANTIDAD_PRODUCTO", v_CANTIDAD_PRODUCTO) :
                new ObjectParameter("V_CANTIDAD_PRODUCTO", typeof(decimal));
    
            var v_ID_PRODUCTOParameter = v_ID_PRODUCTO.HasValue ?
                new ObjectParameter("V_ID_PRODUCTO", v_ID_PRODUCTO) :
                new ObjectParameter("V_ID_PRODUCTO", typeof(decimal));
    
            var v_ID_BOLETAParameter = v_ID_BOLETA.HasValue ?
                new ObjectParameter("V_ID_BOLETA", v_ID_BOLETA) :
                new ObjectParameter("V_ID_BOLETA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_I_DETALLE_BOLETA", v_CANTIDAD_PRODUCTOParameter, v_ID_PRODUCTOParameter, v_ID_BOLETAParameter);
        }
    
        public virtual int SP_I_DETALLE_PEDIDO(Nullable<decimal> nUME_PEDIDO, Nullable<decimal> nUME_DETA_PEDIDO, Nullable<decimal> cANTIDAD_PRODUCTO, Nullable<decimal> pRECIO_PRODUCTO, Nullable<decimal> iD_PRODUCTO, Nullable<decimal> iD_PROVEEDOR, string nOMBRE_PRODUCTO)
        {
            var nUME_PEDIDOParameter = nUME_PEDIDO.HasValue ?
                new ObjectParameter("NUME_PEDIDO", nUME_PEDIDO) :
                new ObjectParameter("NUME_PEDIDO", typeof(decimal));
    
            var nUME_DETA_PEDIDOParameter = nUME_DETA_PEDIDO.HasValue ?
                new ObjectParameter("NUME_DETA_PEDIDO", nUME_DETA_PEDIDO) :
                new ObjectParameter("NUME_DETA_PEDIDO", typeof(decimal));
    
            var cANTIDAD_PRODUCTOParameter = cANTIDAD_PRODUCTO.HasValue ?
                new ObjectParameter("CANTIDAD_PRODUCTO", cANTIDAD_PRODUCTO) :
                new ObjectParameter("CANTIDAD_PRODUCTO", typeof(decimal));
    
            var pRECIO_PRODUCTOParameter = pRECIO_PRODUCTO.HasValue ?
                new ObjectParameter("PRECIO_PRODUCTO", pRECIO_PRODUCTO) :
                new ObjectParameter("PRECIO_PRODUCTO", typeof(decimal));
    
            var iD_PRODUCTOParameter = iD_PRODUCTO.HasValue ?
                new ObjectParameter("ID_PRODUCTO", iD_PRODUCTO) :
                new ObjectParameter("ID_PRODUCTO", typeof(decimal));
    
            var iD_PROVEEDORParameter = iD_PROVEEDOR.HasValue ?
                new ObjectParameter("ID_PROVEEDOR", iD_PROVEEDOR) :
                new ObjectParameter("ID_PROVEEDOR", typeof(decimal));
    
            var nOMBRE_PRODUCTOParameter = nOMBRE_PRODUCTO != null ?
                new ObjectParameter("NOMBRE_PRODUCTO", nOMBRE_PRODUCTO) :
                new ObjectParameter("NOMBRE_PRODUCTO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_I_DETALLE_PEDIDO", nUME_PEDIDOParameter, nUME_DETA_PEDIDOParameter, cANTIDAD_PRODUCTOParameter, pRECIO_PRODUCTOParameter, iD_PRODUCTOParameter, iD_PROVEEDORParameter, nOMBRE_PRODUCTOParameter);
        }
    
        public virtual int SP_I_PEDIDO(Nullable<decimal> iD_PROVEEDOR, Nullable<decimal> iD_USUARIO, string nOMBRE_PROVEEDOR, ObjectParameter oUT_ID_PEDIDO, Nullable<decimal> eSTADO, Nullable<decimal> iSENVIADO, Nullable<decimal> iSANULADO)
        {
            var iD_PROVEEDORParameter = iD_PROVEEDOR.HasValue ?
                new ObjectParameter("ID_PROVEEDOR", iD_PROVEEDOR) :
                new ObjectParameter("ID_PROVEEDOR", typeof(decimal));
    
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(decimal));
    
            var nOMBRE_PROVEEDORParameter = nOMBRE_PROVEEDOR != null ?
                new ObjectParameter("NOMBRE_PROVEEDOR", nOMBRE_PROVEEDOR) :
                new ObjectParameter("NOMBRE_PROVEEDOR", typeof(string));
    
            var eSTADOParameter = eSTADO.HasValue ?
                new ObjectParameter("ESTADO", eSTADO) :
                new ObjectParameter("ESTADO", typeof(decimal));
    
            var iSENVIADOParameter = iSENVIADO.HasValue ?
                new ObjectParameter("ISENVIADO", iSENVIADO) :
                new ObjectParameter("ISENVIADO", typeof(decimal));
    
            var iSANULADOParameter = iSANULADO.HasValue ?
                new ObjectParameter("ISANULADO", iSANULADO) :
                new ObjectParameter("ISANULADO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_I_PEDIDO", iD_PROVEEDORParameter, iD_USUARIOParameter, nOMBRE_PROVEEDORParameter, oUT_ID_PEDIDO, eSTADOParameter, iSENVIADOParameter, iSANULADOParameter);
        }
    
        public virtual int SP_I_PROVEEDOR(string rUT_PROVEEDOR, string rAZON_SOCIAL, Nullable<decimal> fONO, string eMAIL, string gIRO, ObjectParameter v_SALIDA)
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
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_I_PROVEEDOR", rUT_PROVEEDORParameter, rAZON_SOCIALParameter, fONOParameter, eMAILParameter, gIROParameter, v_SALIDA);
        }
    
        public virtual int SP_RESET_SEQ_DETALLE_PEDIDO()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_RESET_SEQ_DETALLE_PEDIDO");
        }
    
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
    
        public virtual int SP_U_BOLETA(Nullable<decimal> v_NUMERO_BOLETA, Nullable<decimal> v_FIADO, string v_TIPO_PAGO, Nullable<decimal> v_TOTAL_BOLETA, Nullable<System.DateTime> v_FECHA_BOLETA)
        {
            var v_NUMERO_BOLETAParameter = v_NUMERO_BOLETA.HasValue ?
                new ObjectParameter("V_NUMERO_BOLETA", v_NUMERO_BOLETA) :
                new ObjectParameter("V_NUMERO_BOLETA", typeof(decimal));
    
            var v_FIADOParameter = v_FIADO.HasValue ?
                new ObjectParameter("V_FIADO", v_FIADO) :
                new ObjectParameter("V_FIADO", typeof(decimal));
    
            var v_TIPO_PAGOParameter = v_TIPO_PAGO != null ?
                new ObjectParameter("V_TIPO_PAGO", v_TIPO_PAGO) :
                new ObjectParameter("V_TIPO_PAGO", typeof(string));
    
            var v_TOTAL_BOLETAParameter = v_TOTAL_BOLETA.HasValue ?
                new ObjectParameter("V_TOTAL_BOLETA", v_TOTAL_BOLETA) :
                new ObjectParameter("V_TOTAL_BOLETA", typeof(decimal));
    
            var v_FECHA_BOLETAParameter = v_FECHA_BOLETA.HasValue ?
                new ObjectParameter("V_FECHA_BOLETA", v_FECHA_BOLETA) :
                new ObjectParameter("V_FECHA_BOLETA", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_U_BOLETA", v_NUMERO_BOLETAParameter, v_FIADOParameter, v_TIPO_PAGOParameter, v_TOTAL_BOLETAParameter, v_FECHA_BOLETAParameter);
        }
    
        public virtual int SP_U_CLIENTE(string v_RUT_CLIENTE, string v_NOMBRE, Nullable<decimal> v_ESTADO)
        {
            var v_RUT_CLIENTEParameter = v_RUT_CLIENTE != null ?
                new ObjectParameter("V_RUT_CLIENTE", v_RUT_CLIENTE) :
                new ObjectParameter("V_RUT_CLIENTE", typeof(string));
    
            var v_NOMBREParameter = v_NOMBRE != null ?
                new ObjectParameter("V_NOMBRE", v_NOMBRE) :
                new ObjectParameter("V_NOMBRE", typeof(string));
    
            var v_ESTADOParameter = v_ESTADO.HasValue ?
                new ObjectParameter("V_ESTADO", v_ESTADO) :
                new ObjectParameter("V_ESTADO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_U_CLIENTE", v_RUT_CLIENTEParameter, v_NOMBREParameter, v_ESTADOParameter);
        }
    
        public virtual int SP_U_DETALLE_BOLETA(Nullable<decimal> v_ID_DETALLE, string v_CANTIDAD_PRODUCTO, Nullable<decimal> v_ID_PRODUCTO, Nullable<decimal> v_ID_BOLETA)
        {
            var v_ID_DETALLEParameter = v_ID_DETALLE.HasValue ?
                new ObjectParameter("V_ID_DETALLE", v_ID_DETALLE) :
                new ObjectParameter("V_ID_DETALLE", typeof(decimal));
    
            var v_CANTIDAD_PRODUCTOParameter = v_CANTIDAD_PRODUCTO != null ?
                new ObjectParameter("V_CANTIDAD_PRODUCTO", v_CANTIDAD_PRODUCTO) :
                new ObjectParameter("V_CANTIDAD_PRODUCTO", typeof(string));
    
            var v_ID_PRODUCTOParameter = v_ID_PRODUCTO.HasValue ?
                new ObjectParameter("V_ID_PRODUCTO", v_ID_PRODUCTO) :
                new ObjectParameter("V_ID_PRODUCTO", typeof(decimal));
    
            var v_ID_BOLETAParameter = v_ID_BOLETA.HasValue ?
                new ObjectParameter("V_ID_BOLETA", v_ID_BOLETA) :
                new ObjectParameter("V_ID_BOLETA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_U_DETALLE_BOLETA", v_ID_DETALLEParameter, v_CANTIDAD_PRODUCTOParameter, v_ID_PRODUCTOParameter, v_ID_BOLETAParameter);
        }
    
        public virtual int SP_U_FIADOR(string rUT)
        {
            var rUTParameter = rUT != null ?
                new ObjectParameter("RUT", rUT) :
                new ObjectParameter("RUT", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_U_FIADOR", rUTParameter);
        }
    
        public virtual int SP_U_PROVEEDOR(string v_RUT_PROVEEDOR, string v_RAZON_SOCIAL, Nullable<decimal> v_FONO, string v_EMAIL, string v_GIRO, Nullable<decimal> v_ESTADO)
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
    
            var v_ESTADOParameter = v_ESTADO.HasValue ?
                new ObjectParameter("V_ESTADO", v_ESTADO) :
                new ObjectParameter("V_ESTADO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_U_PROVEEDOR", v_RUT_PROVEEDORParameter, v_RAZON_SOCIALParameter, v_FONOParameter, v_EMAILParameter, v_GIROParameter, v_ESTADOParameter);
        }
    
        public virtual int SP_AUTORIZAR_CLIENTE(string v_RUT_CLIENTE, Nullable<decimal> v_AUTORIZADO_FIADO)
        {
            var v_RUT_CLIENTEParameter = v_RUT_CLIENTE != null ?
                new ObjectParameter("V_RUT_CLIENTE", v_RUT_CLIENTE) :
                new ObjectParameter("V_RUT_CLIENTE", typeof(string));
    
            var v_AUTORIZADO_FIADOParameter = v_AUTORIZADO_FIADO.HasValue ?
                new ObjectParameter("V_AUTORIZADO_FIADO", v_AUTORIZADO_FIADO) :
                new ObjectParameter("V_AUTORIZADO_FIADO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_AUTORIZAR_CLIENTE", v_RUT_CLIENTEParameter, v_AUTORIZADO_FIADOParameter);
        }
    
        public virtual int SP_U_PAGAR_FIADO(Nullable<decimal> v_ID_FIADO, string v_ESTADO, Nullable<System.DateTime> v_FECHA_PAGO)
        {
            var v_ID_FIADOParameter = v_ID_FIADO.HasValue ?
                new ObjectParameter("V_ID_FIADO", v_ID_FIADO) :
                new ObjectParameter("V_ID_FIADO", typeof(decimal));
    
            var v_ESTADOParameter = v_ESTADO != null ?
                new ObjectParameter("V_ESTADO", v_ESTADO) :
                new ObjectParameter("V_ESTADO", typeof(string));
    
            var v_FECHA_PAGOParameter = v_FECHA_PAGO.HasValue ?
                new ObjectParameter("V_FECHA_PAGO", v_FECHA_PAGO) :
                new ObjectParameter("V_FECHA_PAGO", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_U_PAGAR_FIADO", v_ID_FIADOParameter, v_ESTADOParameter, v_FECHA_PAGOParameter);
        }
    
        public virtual int SP_I_PRODUCTO(string v_DESCRIPCION, Nullable<decimal> v_PRECIO_VENTA, string v_UNIDAD_MEDIDA, Nullable<decimal> v_STOCK, Nullable<System.DateTime> v_FECHA_VENCIMIETO, Nullable<decimal> v_PRECIO_COMPRA, Nullable<decimal> v_STOCK_CRITICO, Nullable<decimal> v_ID_PROVEEDOR, Nullable<decimal> v_ID_TIPO_PRODUCTO, Nullable<decimal> v_ID_TIPO_MONEDA, ObjectParameter iD_PRODUCTO)
        {
            var v_DESCRIPCIONParameter = v_DESCRIPCION != null ?
                new ObjectParameter("V_DESCRIPCION", v_DESCRIPCION) :
                new ObjectParameter("V_DESCRIPCION", typeof(string));
    
            var v_PRECIO_VENTAParameter = v_PRECIO_VENTA.HasValue ?
                new ObjectParameter("V_PRECIO_VENTA", v_PRECIO_VENTA) :
                new ObjectParameter("V_PRECIO_VENTA", typeof(decimal));
    
            var v_UNIDAD_MEDIDAParameter = v_UNIDAD_MEDIDA != null ?
                new ObjectParameter("V_UNIDAD_MEDIDA", v_UNIDAD_MEDIDA) :
                new ObjectParameter("V_UNIDAD_MEDIDA", typeof(string));
    
            var v_STOCKParameter = v_STOCK.HasValue ?
                new ObjectParameter("V_STOCK", v_STOCK) :
                new ObjectParameter("V_STOCK", typeof(decimal));
    
            var v_FECHA_VENCIMIETOParameter = v_FECHA_VENCIMIETO.HasValue ?
                new ObjectParameter("V_FECHA_VENCIMIETO", v_FECHA_VENCIMIETO) :
                new ObjectParameter("V_FECHA_VENCIMIETO", typeof(System.DateTime));
    
            var v_PRECIO_COMPRAParameter = v_PRECIO_COMPRA.HasValue ?
                new ObjectParameter("V_PRECIO_COMPRA", v_PRECIO_COMPRA) :
                new ObjectParameter("V_PRECIO_COMPRA", typeof(decimal));
    
            var v_STOCK_CRITICOParameter = v_STOCK_CRITICO.HasValue ?
                new ObjectParameter("V_STOCK_CRITICO", v_STOCK_CRITICO) :
                new ObjectParameter("V_STOCK_CRITICO", typeof(decimal));
    
            var v_ID_PROVEEDORParameter = v_ID_PROVEEDOR.HasValue ?
                new ObjectParameter("V_ID_PROVEEDOR", v_ID_PROVEEDOR) :
                new ObjectParameter("V_ID_PROVEEDOR", typeof(decimal));
    
            var v_ID_TIPO_PRODUCTOParameter = v_ID_TIPO_PRODUCTO.HasValue ?
                new ObjectParameter("V_ID_TIPO_PRODUCTO", v_ID_TIPO_PRODUCTO) :
                new ObjectParameter("V_ID_TIPO_PRODUCTO", typeof(decimal));
    
            var v_ID_TIPO_MONEDAParameter = v_ID_TIPO_MONEDA.HasValue ?
                new ObjectParameter("V_ID_TIPO_MONEDA", v_ID_TIPO_MONEDA) :
                new ObjectParameter("V_ID_TIPO_MONEDA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_I_PRODUCTO", v_DESCRIPCIONParameter, v_PRECIO_VENTAParameter, v_UNIDAD_MEDIDAParameter, v_STOCKParameter, v_FECHA_VENCIMIETOParameter, v_PRECIO_COMPRAParameter, v_STOCK_CRITICOParameter, v_ID_PROVEEDORParameter, v_ID_TIPO_PRODUCTOParameter, v_ID_TIPO_MONEDAParameter, iD_PRODUCTO);
        }
    
        public virtual int SP_I_PRODUCTO1(string v_DESCRIPCION, Nullable<decimal> v_PRECIO_VENTA, string v_UNIDAD_MEDIDA, Nullable<decimal> v_STOCK, Nullable<System.DateTime> v_FECHA_VENCIMIETO, Nullable<decimal> v_PRECIO_COMPRA, Nullable<decimal> v_STOCK_CRITICO, Nullable<decimal> v_ID_PROVEEDOR, Nullable<decimal> v_ID_TIPO_PRODUCTO, Nullable<decimal> v_ID_TIPO_MONEDA, ObjectParameter iD_PRODUCTO)
        {
            var v_DESCRIPCIONParameter = v_DESCRIPCION != null ?
                new ObjectParameter("V_DESCRIPCION", v_DESCRIPCION) :
                new ObjectParameter("V_DESCRIPCION", typeof(string));
    
            var v_PRECIO_VENTAParameter = v_PRECIO_VENTA.HasValue ?
                new ObjectParameter("V_PRECIO_VENTA", v_PRECIO_VENTA) :
                new ObjectParameter("V_PRECIO_VENTA", typeof(decimal));
    
            var v_UNIDAD_MEDIDAParameter = v_UNIDAD_MEDIDA != null ?
                new ObjectParameter("V_UNIDAD_MEDIDA", v_UNIDAD_MEDIDA) :
                new ObjectParameter("V_UNIDAD_MEDIDA", typeof(string));
    
            var v_STOCKParameter = v_STOCK.HasValue ?
                new ObjectParameter("V_STOCK", v_STOCK) :
                new ObjectParameter("V_STOCK", typeof(decimal));
    
            var v_FECHA_VENCIMIETOParameter = v_FECHA_VENCIMIETO.HasValue ?
                new ObjectParameter("V_FECHA_VENCIMIETO", v_FECHA_VENCIMIETO) :
                new ObjectParameter("V_FECHA_VENCIMIETO", typeof(System.DateTime));
    
            var v_PRECIO_COMPRAParameter = v_PRECIO_COMPRA.HasValue ?
                new ObjectParameter("V_PRECIO_COMPRA", v_PRECIO_COMPRA) :
                new ObjectParameter("V_PRECIO_COMPRA", typeof(decimal));
    
            var v_STOCK_CRITICOParameter = v_STOCK_CRITICO.HasValue ?
                new ObjectParameter("V_STOCK_CRITICO", v_STOCK_CRITICO) :
                new ObjectParameter("V_STOCK_CRITICO", typeof(decimal));
    
            var v_ID_PROVEEDORParameter = v_ID_PROVEEDOR.HasValue ?
                new ObjectParameter("V_ID_PROVEEDOR", v_ID_PROVEEDOR) :
                new ObjectParameter("V_ID_PROVEEDOR", typeof(decimal));
    
            var v_ID_TIPO_PRODUCTOParameter = v_ID_TIPO_PRODUCTO.HasValue ?
                new ObjectParameter("V_ID_TIPO_PRODUCTO", v_ID_TIPO_PRODUCTO) :
                new ObjectParameter("V_ID_TIPO_PRODUCTO", typeof(decimal));
    
            var v_ID_TIPO_MONEDAParameter = v_ID_TIPO_MONEDA.HasValue ?
                new ObjectParameter("V_ID_TIPO_MONEDA", v_ID_TIPO_MONEDA) :
                new ObjectParameter("V_ID_TIPO_MONEDA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_I_PRODUCTO1", v_DESCRIPCIONParameter, v_PRECIO_VENTAParameter, v_UNIDAD_MEDIDAParameter, v_STOCKParameter, v_FECHA_VENCIMIETOParameter, v_PRECIO_COMPRAParameter, v_STOCK_CRITICOParameter, v_ID_PROVEEDORParameter, v_ID_TIPO_PRODUCTOParameter, v_ID_TIPO_MONEDAParameter, iD_PRODUCTO);
        }
    
        public virtual int SP_ANULA_PEDIDO(Nullable<decimal> nUME_PEDIDO)
        {
            var nUME_PEDIDOParameter = nUME_PEDIDO.HasValue ?
                new ObjectParameter("NUME_PEDIDO", nUME_PEDIDO) :
                new ObjectParameter("NUME_PEDIDO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ANULA_PEDIDO", nUME_PEDIDOParameter);
        }
    
        public virtual int SP_ELIMINA_PEDIDO(Nullable<decimal> nUME_PEDIDO)
        {
            var nUME_PEDIDOParameter = nUME_PEDIDO.HasValue ?
                new ObjectParameter("NUME_PEDIDO", nUME_PEDIDO) :
                new ObjectParameter("NUME_PEDIDO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ELIMINA_PEDIDO", nUME_PEDIDOParameter);
        }
    
        public virtual int SP_ENVIA_PEDIDO(Nullable<decimal> nUME_PEDIDO)
        {
            var nUME_PEDIDOParameter = nUME_PEDIDO.HasValue ?
                new ObjectParameter("NUME_PEDIDO", nUME_PEDIDO) :
                new ObjectParameter("NUME_PEDIDO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ENVIA_PEDIDO", nUME_PEDIDOParameter);
        }
    }
}
