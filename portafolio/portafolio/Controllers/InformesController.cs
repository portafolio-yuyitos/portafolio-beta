using Oracle.ManagedDataAccess.Client;
using portafolio.Models;
using portafolio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace portafolio.Controllers
{
    public class InformesController : Controller
    {
        // GET: Informes
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                Informes inf = new Informes
                {
                    InformClientesGasto = ClientesGastoList(),
                    InformeClienteFiados = ClientesFiadosList(),
                    InformeProveedorProducto = ProveedorProductoList(),
                    InformePeoresFiadores = PeoresFiadoresList(),
                    InformeBoletas30Dias = Boletas30DiasList(),
                    InformeStockProductos = ProductosPorStock(1)

                };
                return View(inf);
            }
            return Redirect("~/Login/");
        }

        

        // ######################
        //    INFORMES CLIENTE
        // ######################
        public void EClientes()
        {
            var grid = new GridView();
            ClientesController cli = new ClientesController();
            grid.DataSource = cli.ClientesList();
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=ExportedClientList.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }

        public void EClientesGasto()
        {
            var grid = new GridView();
            grid.DataSource = ClientesGastoList();
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=EClienteGasto.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }
        

        public void EClientesFiados()
        {
            var grid = new GridView();
            grid.DataSource = ClientesFiadosList();
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=EClienteFiado.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }

        public void EProveedorProducto()
        {
            var grid = new GridView();
            grid.DataSource = ProveedorProductoList();
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=EProveedorProducto.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }

        public void EPeoresFiadores()
        {
            var grid = new GridView();
            grid.DataSource = PeoresFiadoresList();
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=EPeoresFiadores.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }


        public List<ClientesGasto> ClientesGastoList()
        {
            List<ClientesGasto> lista = new List<ClientesGasto>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_INFORMES.TOT_BOL_X_CLIE";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "boletaCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        lista.Add(new ClientesGasto
                        {
                            Id = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("ID")),
                            Rut = _rdrObj.GetString(_rdrObj.GetOrdinal("RUT")),
                            Nombre = _rdrObj.GetString(_rdrObj.GetOrdinal("NOMBRE")),
                            TotalCompras = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("TOTAL COMPRAS")),
                            FechUltiCompra = _rdrObj.GetDateTime(_rdrObj.GetOrdinal("FECHA ULT. COMPRA")),
                            CanBoletasAnuladas = _rdrObj.GetInt32(_rdrObj.GetOrdinal("BOLETAS ANULADAS"))

                        });
                    }
                }

                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }
        public List<ClienteFiados_I> ClientesFiadosList()
        {
            List<ClienteFiados_I> lista = new List<ClienteFiados_I>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_INFORMES.TOT_CLIENTES_FIADOS";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "boletaCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        lista.Add(new ClienteFiados_I
                        {
                            Id = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("ID")),
                            Rut = _rdrObj.GetString(_rdrObj.GetOrdinal("RUT")),
                            Nombre = _rdrObj.GetString(_rdrObj.GetOrdinal("NOMBRE")),
                            MontoSolicitado = _rdrObj.GetInt32(_rdrObj.GetOrdinal("MONTO_SOLICITADO")),
                            MontoPagado = _rdrObj.GetInt32(_rdrObj.GetOrdinal("MONTO_PAGADO")),
                            FechaCompra = _rdrObj.GetDateTime(_rdrObj.GetOrdinal("FECHA_COMPRA")),
                            EstadoPago = _rdrObj.GetString(_rdrObj.GetOrdinal("ESTADO_PAGO")),
                            IdFiado = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_FIADO"))
                        });
                    }
                }

                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }
        public List<ProveedorProducto_I> ProveedorProductoList()
        {
            List<ProveedorProducto_I> lista = new List<ProveedorProducto_I>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_INFORMES.PROVEEDOR_PRODUCTO";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "boletaCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        lista.Add(new ProveedorProducto_I
                        {
                            IdProveedor = _rdrObj.GetInt32(_rdrObj.GetOrdinal("IDENTIFICADOR PROVEEDOR")),
                            RutProveedor = _rdrObj.GetString(_rdrObj.GetOrdinal("RUT")),
                            RazonSocial = _rdrObj.GetString(_rdrObj.GetOrdinal("RAZON SOCIAL")),
                            Giro = _rdrObj.GetString(_rdrObj.GetOrdinal("GIRO")),
                            IdProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("IDENTIFICADOR PRODUCTO")),
                            DescProducto = _rdrObj.GetString(_rdrObj.GetOrdinal("DESCRIPCION PRODUCTO")),
                            PrecioVenta = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PRECIO")),
                            Stock = _rdrObj.GetInt32(_rdrObj.GetOrdinal("STOCK"))
                        });
                    }
                }

                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }
        public List<PeoresFiadores_I> PeoresFiadoresList()
        {
            List<PeoresFiadores_I> lista = new List<PeoresFiadores_I>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_INFORMES.PEORES_FIADORES";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "auxCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        lista.Add(new PeoresFiadores_I
                        {
                            IdCliente = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_CLIENTE")),
                            RutCliente = _rdrObj.GetString(_rdrObj.GetOrdinal("RUT_CLIENTE")),
                            Nombre = _rdrObj.GetString(_rdrObj.GetOrdinal("NOMBRE")),
                            IdFiado = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_FIADO")),
                            MontoAdeudado = _rdrObj.GetInt32(_rdrObj.GetOrdinal("MONTO ADEUDADO")),

                        });
                    }
                }

                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }
        public List<Boleta> Boletas30DiasList()
        {
            List<Boleta> lista = new List<Boleta>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_INFORMES.BOLETAS_30_DIAS";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "auxCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        lista.Add(new Boleta
                        {
                            NumeroBoleta = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_BOLETA")),
                            Fiado = _rdrObj.GetInt32(_rdrObj.GetOrdinal("FIADO")),
                            TipoPago = _rdrObj.GetString(_rdrObj.GetOrdinal("TIPO_PAGO")),
                            TotalBoleta = _rdrObj.GetInt32(_rdrObj.GetOrdinal("TOTAL_BOLETA")),
                            FechaBoleta = _rdrObj.GetDateTime(_rdrObj.GetOrdinal("FECHA_BOLETA")),
                            IdCliente = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_CLIENTE")),
                            IsAnulada = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ISANULADA"))

                        });
                    }
                }

                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }

        //##############
        //  SE LE PUEDE PASAR 1 PARA QUE DEVUELVA ORDEN ASCENDENTE POR PORCENTAJE
        //  O CERO Y DEVUELVE DESCENDENTE
        //##############

        public List<ProductoPorcentajeStock> ProductosPorStock(int modificador)
        {
            
            List<ProductoPorcentajeStock> lista = new List<ProductoPorcentajeStock>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_INFORMES.PRODUCTOS_POCO_STOCK";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter modifier = new OracleParameter();
                modifier.ParameterName = "modificador";
                modifier.OracleDbType = OracleDbType.Decimal;
                modifier.Direction = System.Data.ParameterDirection.Input;
                modifier.Value = modificador;
                _comObj.Parameters.Add(modifier);


                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "auxCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        lista.Add(new ProductoPorcentajeStock
                        {
                            IdProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PRODUCTO")),
                            Descripcion = _rdrObj.GetString(_rdrObj.GetOrdinal("DESCRIPCION")),
                            PrecioVenta = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PRECIO_VENTA")),
                            UnidadMedida = _rdrObj.GetString(_rdrObj.GetOrdinal("UNIDAD_MEDIDA")),
                            Stock = _rdrObj.GetInt32(_rdrObj.GetOrdinal("STOCK")),
                            FechaVentimiento = _rdrObj.GetDateTime(_rdrObj.GetOrdinal("FECHA_VENCIMIENTO")),
                            PrecioCompra = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PRECIO_COMPRA")),
                            StockCritico = _rdrObj.GetInt32(_rdrObj.GetOrdinal("STOCK_CRITICO")),
                            IdProveedor = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PROVEEDOR")),
                            IdTipoProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_TIPO_PRODUCTO")),
                            IdTipoMoneda = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_TIPO_MONEDA")),
                            PorcentajeStock = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PORCENTAJE_STOCK"))

                        });
                    }
                }

                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }

    }
}