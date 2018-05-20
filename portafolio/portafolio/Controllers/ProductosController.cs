using Oracle.ManagedDataAccess.Client;
using portafolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portafolio.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ProductosPorProveedor(int? idProveedor)
        {
            List<Producto> prods = new List<Producto>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_PRODUCTOS.SP_S_PRODUCTOS_PROVEEDOR";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _IdProvParam = new OracleParameter();
                _IdProvParam.ParameterName = "idProveedor";
                _IdProvParam.OracleDbType = OracleDbType.Int32;
                _IdProvParam.Direction = System.Data.ParameterDirection.Input;
                _IdProvParam.Value = idProveedor;
                _comObj.Parameters.Add(_IdProvParam);

                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "provCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        prods.Add(new Producto
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
                            IdTipoMoneda = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_TIPO_MONEDA"))

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

            return new JsonResult()
            {
                Data = prods,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
    }
}