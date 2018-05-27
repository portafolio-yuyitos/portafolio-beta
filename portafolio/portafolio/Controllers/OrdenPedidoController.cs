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
    public class OrdenPedidoController : Controller
    {
        // GET: OrdenPedido
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                return View();
            }
            return Redirect("~/Login/");
        }

        // ###########################
        //      DEVUELVE PEDIDOS
        // ###########################
        public List<Pedido> ObtenerPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_PEDIDOS.SP_S_PEDIDO";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                /*OracleParameter _IdProvParam = new OracleParameter();
                _IdProvParam.ParameterName = "idProveedor";
                _IdProvParam.OracleDbType = OracleDbType.Int32;
                _IdProvParam.Direction = System.Data.ParameterDirection.Input;
                _IdProvParam.Value = idProveedor;
                _comObj.Parameters.Add(_IdProvParam);*/

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
                        pedidos.Add(new Pedido
                        {
                            NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                            IdProveedor = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PROVEEDOR")),
                            IdUsuario = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_USUARIO")),
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

            return pedidos;
        }

        public JsonResult PedidosEnJson()
        {
            return new JsonResult()
            {
                Data = ObtenerPedidos(),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        // ################################
        //      DEVUELVE PEDIDO POR NUMERO PEDIDO
        // ################################
        public JsonResult ObtenerPedidoPorNumePedido(int numePed)
        {
            List<Pedido> pedidos = new List<Pedido>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_PEDIDOS.SP_S_PEDIDO_NUMEPEDI";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _NumePediParam = new OracleParameter();
                _NumePediParam.ParameterName = "numeroPedido";
                _NumePediParam.OracleDbType = OracleDbType.Int32;
                _NumePediParam.Direction = System.Data.ParameterDirection.Input;
                _NumePediParam.Value = numePed;
                _comObj.Parameters.Add(_NumePediParam);

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
                        pedidos.Add(new Pedido
                        {
                            NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                            IdProveedor = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PROVEEDOR")),
                            IdUsuario = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_USUARIO")),
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
                Data = pedidos,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        // ################################
        //      DEVUELVE PEDIDO POR NUMERO PEDIDO
        //      RETORNA PEDIDO
        // ################################
        public Pedido ObtenerPedido(int numePed)
        {
            Pedido pedido = new Pedido();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_PEDIDOS.SP_S_PEDIDO_NUMEPEDI";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _NumePediParam = new OracleParameter();
                _NumePediParam.ParameterName = "numeroPedido";
                _NumePediParam.OracleDbType = OracleDbType.Int32;
                _NumePediParam.Direction = System.Data.ParameterDirection.Input;
                _NumePediParam.Value = numePed;
                _comObj.Parameters.Add(_NumePediParam);

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
                        pedido = new Pedido
                        {
                            NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                            IdProveedor = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PROVEEDOR")),
                            IdUsuario = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_USUARIO")),
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

            return pedido;
        }

        // ########################################
        //      DEVUELVE PEDIDOS POR PROVEEDOR
        // ########################################
        public JsonResult ObtenerPedidosPorProveedor(int idProveedor)
        {
            List<Pedido> pedidos = new List<Pedido>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_PEDIDOS.SP_S_PEDIDOS_PROVEEDOR";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _IdProvParam = new OracleParameter();
                _IdProvParam.ParameterName = "idProveedor";
                _IdProvParam.OracleDbType = OracleDbType.Int32;
                _IdProvParam.Direction = System.Data.ParameterDirection.Input;
                _IdProvParam.Value = idProveedor;
                _comObj.Parameters.Add(_IdProvParam);

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
                        pedidos.Add(new Pedido
                        {
                            NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                            IdProveedor = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PROVEEDOR")),
                            IdUsuario = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_USUARIO")),
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
                Data = pedidos,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        // ########################################
        //      DEVUELVE TODOS LOS DETALLES
        // ########################################
        public JsonResult ObtenerDetallesPedidos()
        {
            List<DetallePedido> detalles = new List<DetallePedido>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_DETALLE_PEDIDO.SP_S_DETALLE_PEDIDO";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                /*OracleParameter _IdProvParam = new OracleParameter();
                _IdProvParam.ParameterName = "idProveedor";
                _IdProvParam.OracleDbType = OracleDbType.Int32;
                _IdProvParam.Direction = System.Data.ParameterDirection.Input;
                _IdProvParam.Value = idProveedor;
                _comObj.Parameters.Add(_IdProvParam);*/

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
                        detalles.Add(new DetallePedido
                        {
                            NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                            NumeroDetalle = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_DETALLE")),
                            IdProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PRODUCTO")),
                            CantidadProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("CANTIDAD_PRODUCTO")),
                            PrecioProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PRECIO_PRODUCTO")),
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
                Data = detalles,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        // ############################################
        //      DEVUELVE DETALLES POR NUMERO PEDIDO
        // ############################################
        public JsonResult ObtenerDetallesPedidosPorNumeroPedido(int numePed)
        {
            List<DetallePedido> detalles = new List<DetallePedido>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_DETALLE_PEDIDO.SP_S_DETAPEDIDO_NUME_PEDIDO";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _IdProvParam = new OracleParameter();
                _IdProvParam.ParameterName = "numeroPedido";
                _IdProvParam.OracleDbType = OracleDbType.Int32;
                _IdProvParam.Direction = System.Data.ParameterDirection.Input;
                _IdProvParam.Value = numePed;
                _comObj.Parameters.Add(_IdProvParam);

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
                        detalles.Add(new DetallePedido
                        {
                            NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                            NumeroDetalle = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_DETALLE")),
                            IdProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PRODUCTO")),
                            CantidadProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("CANTIDAD_PRODUCTO")),
                            PrecioProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PRECIO_PRODUCTO")),
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
                Data = detalles,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        // ############################################
        //      DEVUELVE DETALLES POR NUMERO PEDIDO
        //      RETORNA LIST<DETALLE_PEDIDO>
        // ############################################
        public List<DetallePedido> ObtDetallesPorNumPedido(int numePed)
        {
            List<DetallePedido> detalles = new List<DetallePedido>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_DETALLE_PEDIDO.SP_S_DETAPEDIDO_NUME_PEDIDO";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _IdProvParam = new OracleParameter();
                _IdProvParam.ParameterName = "numeroPedido";
                _IdProvParam.OracleDbType = OracleDbType.Int32;
                _IdProvParam.Direction = System.Data.ParameterDirection.Input;
                _IdProvParam.Value = numePed;
                _comObj.Parameters.Add(_IdProvParam);

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
                        detalles.Add(new DetallePedido
                        {
                            NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                            NumeroDetalle = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_DETALLE")),
                            IdProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PRODUCTO")),
                            CantidadProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("CANTIDAD_PRODUCTO")),
                            PrecioProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PRECIO_PRODUCTO")),
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

            return detalles;
        }

        // ###########################################################
        //      DEVUELVE DETALLES POR NUMERO PEDIDO Y NUMERO DETALLE
        // ###########################################################
        public JsonResult ObDetaPediPorNumePediNumeDeta(int numePed, int numeDetaPedi)
        {
            List<DetallePedido> detalles = new List<DetallePedido>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_DETALLE_PEDIDO.SP_S_DETAPEDIDO_NUME_DETA";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _NumePediParam = new OracleParameter();
                _NumePediParam.ParameterName = "numeroPedido";
                _NumePediParam.OracleDbType = OracleDbType.Int32;
                _NumePediParam.Direction = System.Data.ParameterDirection.Input;
                _NumePediParam.Value = numePed;
                _comObj.Parameters.Add(_NumePediParam);

                OracleParameter _NumeDeta = new OracleParameter();
                _NumeDeta.ParameterName = "numeDetaPedido";
                _NumeDeta.OracleDbType = OracleDbType.Int32;
                _NumeDeta.Direction = System.Data.ParameterDirection.Input;
                _NumeDeta.Value = numeDetaPedi;
                _comObj.Parameters.Add(_NumeDeta);

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
                        detalles.Add(new DetallePedido
                        {
                            NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                            NumeroDetalle = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_DETALLE")),
                            IdProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PRODUCTO")),
                            CantidadProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("CANTIDAD_PRODUCTO")),
                            PrecioProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PRECIO_PRODUCTO")),
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
                Data = detalles,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        // ###########################################################
        //      DEVUELVE DETALLES POR ID PRODUCTO
        // ###########################################################
        public JsonResult ObtenerPedidosPorIdProducto(int idProducto)
        {
            List<DetallePedido> detalles = new List<DetallePedido>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_DETALLE_PEDIDO.SP_S_DETALLE_PEDIDOS_PRODUCTO";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _IdProdParam = new OracleParameter();
                _IdProdParam.ParameterName = "numeroPedido";
                _IdProdParam.OracleDbType = OracleDbType.Int32;
                _IdProdParam.Direction = System.Data.ParameterDirection.Input;
                _IdProdParam.Value = idProducto;
                _comObj.Parameters.Add(_IdProdParam);

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
                        detalles.Add(new DetallePedido
                        {
                            NumeroPedido = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_PEDIDO")),
                            NumeroDetalle = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_DETALLE")),
                            IdProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_PRODUCTO")),
                            CantidadProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("CANTIDAD_PRODUCTO")),
                            PrecioProducto = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PRECIO_PRODUCTO")),
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
                Data = detalles,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }


        // #################################
        //      Genera orden de pedido 
        //      CON NUMERO PEDIDO
        // #################################
        public JsonResult OrdenDePedido(int numePedido)
        {
            OPedidoDetalles orden = new OPedidoDetalles();

            orden.Encabezado = ObtenerPedido(numePedido);
            orden.Detalles = ObtDetallesPorNumPedido(numePedido);


            return new JsonResult()
            {
                Data = orden,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };

        }

        public JsonResult TodasLasOrdenes()
        {
            // CREAMOS UN LISTADO DE PEDIDOS
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = ObtenerPedidos();  //hacemos que contenga todos los pedidos

            // CREAMOS UN LIST DEL view-model OPedidoDetalles
            List<OPedidoDetalles> ordenes = new List<OPedidoDetalles>();

            // INSTANCIAMOS UNA OBJ DEL view-model OPedidoDetalles
            OPedidoDetalles orden;

            //  POR CADA PEDIDO, LLENAREMOS UNA ORDEN Y LUEGO LA INSERTAREMOS EN EL LISTADO DE ORDENES
            foreach (Pedido pedido in pedidos)
            {
                orden = new OPedidoDetalles { Encabezado = pedido, Detalles = ObtDetallesPorNumPedido(pedido.NumeroPedido) };

                ordenes.Add(orden);
            }


            // RETORNAMOS EL LISTADO DE ORDENES
            return new JsonResult()
            {
                Data = ordenes,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };



        }

    }
}