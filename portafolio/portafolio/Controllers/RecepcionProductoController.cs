using Oracle.ManagedDataAccess.Client;
using portafolio.Models;
using portafolio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portafolio.Controllers
{
    public class RecepcionProductoController : Controller
    {
        // GET: RecepcionProducto
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                return View();
            }
            return Redirect("~/Login/");
        }

        


        


        // ###################################
        //     TRAE UN PEDIDO POR N° PEDIDO
        // ###################################
        public JsonResult ObPedidoPorNPedido(int numePedido)
        {
            OPedidoDetalles lista = SelectPedido(numePedido);
            return new JsonResult()
            {
                Data = lista,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        public OPedidoDetalles SelectPedido(int numePed)
        {
            OPedidoDetalles ordenPedido = new OPedidoDetalles();
            Pedido ped;
            List<DetallePedido> detaPed;

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_PEDIDOS.SP_S_PEDIDO";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;



                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "pedidosCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        int npedidodb = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO"));
                        if (npedidodb == numePed)
                        {

                            ped = new Pedido
                            {
                                NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                                IdProveedor = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PROVEEDOR")),
                                IdUsuario = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_USUARIO")),
                                Estado = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ESTADO")),
                                IsAnulada = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ISANULADA")),
                                IsEnviado = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ISENVIADO")),
                                NombreProveedor = _rdrObj.GetString(_rdrObj.GetOrdinal("NOMBRE_PROVEEDOR"))
                            };

                            detaPed = new List<DetallePedido>();
                            detaPed = SelectDetalles(ped.NumeroPedido);


                            ordenPedido.Encabezado = ped;
                            ordenPedido.Detalles = detaPed;
                        }
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

            return ordenPedido;
        }

        public List<DetallePedido> SelectDetalles(int numeroPedido)
        {

            List<DetallePedido> detaPed = new List<DetallePedido>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_DETALLE_PEDIDO.SP_S_DETAPEDIDO_NUME_PEDIDO";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter _numePediParam = new OracleParameter();
                _numePediParam.ParameterName = "numeroPedido";
                _numePediParam.OracleDbType = OracleDbType.Int32;
                _numePediParam.Direction = System.Data.ParameterDirection.Input;
                _numePediParam.Value = numeroPedido;
                _comObj.Parameters.Add(_numePediParam);



                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "detaPedidosCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        detaPed.Add(new DetallePedido
                        {
                            NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                            NumeroDetalle = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_DETALLE")),
                            IdProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PRODUCTO")),
                            NombreProducto = _rdrObj.GetString(_rdrObj.GetOrdinal("NOMBRE_PRODUCTO")),
                            CantidadProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("CANTIDAD_PRODUCTO")),
                            PrecioProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PRECIO_PRODUCTO")),
                            IdProveedor = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PROVEEDOR"))
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

            return detaPed;
        }

        public JsonResult BuscarUsuario(int idUsuario)
        {
            Usuario usu = new Usuario();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_RECEPCION.SP_S_BUSCAUSUARIO";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter _numePediParam = new OracleParameter();
                _numePediParam.ParameterName = "idUsuarioPedido";
                _numePediParam.OracleDbType = OracleDbType.Int32;
                _numePediParam.Direction = System.Data.ParameterDirection.Input;
                _numePediParam.Value = idUsuario;
                _comObj.Parameters.Add(_numePediParam);



                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "pedidosCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        usu = new Usuario
                        {
                            IdUsuario = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_USUARIO")),
                            Nombre = _rdrObj.GetString(_rdrObj.GetOrdinal("NOMBRE")),
                            Clave = _rdrObj.GetString(_rdrObj.GetOrdinal("CLAVE")),
                            IdRol = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_ROL"))
                            
                            
                        };
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

            return new JsonResult() {
                Data = usu.Nombre };
            ;

        }


        public JsonResult BuscarProveedor(int idProveedor)
        {
            Proveedor prov = new Proveedor();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_RECEPCION.SP_S_BUSCAPROV";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter _numePediParam = new OracleParameter();
                _numePediParam.ParameterName = "idProveedor";
                _numePediParam.OracleDbType = OracleDbType.Int32;
                _numePediParam.Direction = System.Data.ParameterDirection.Input;
                _numePediParam.Value = idProveedor;
                _comObj.Parameters.Add(_numePediParam);



                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "pedidosCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        prov = new Proveedor
                        {
                            IdProveedor = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PROVEEDOR")),
                            Email = _rdrObj.GetString(_rdrObj.GetOrdinal("EMAIL")),
                            RazonSocial = _rdrObj.GetString(_rdrObj.GetOrdinal("RAZON_SOCIAL")),
                            Estado = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ESTADO")),
                            Fono = _rdrObj.GetInt64(_rdrObj.GetOrdinal("FONO")),
                            Giro = _rdrObj.GetString(_rdrObj.GetOrdinal("GIRO")),
                            RutProveedor = _rdrObj.GetString(_rdrObj.GetOrdinal("RUT_PROVEEDOR"))
                        };
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
                Data = prov
            };
            

        }

    }
}