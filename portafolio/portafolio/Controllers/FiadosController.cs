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
    public class FiadosController : Controller
    {
        // GET: Fiados
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                List<ClienteFiados> fiados = ObtenerFiadosCliente();


                return View(fiados);
            }
            return Redirect("~/Login/");
        }

        

        public List<ClienteFiados> ObtenerFiadosCliente()
        {
            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            // Traer todos los clientes
            List<Cliente> lista = ObtenerClientes();

            // Crear lista del view-model Cliete + Todos fiados (ClienteFiados)
            // Almacena un cliente y una colección de fiados.
            List<ClienteFiados> listaClientesFiados = new List<ClienteFiados>();

            try
            {
                foreach (var item in lista)
                {
                    // Por cada cliente en la lista de clientes:

                    // Crea un view-model
                    ClienteFiados clifi = new ClienteFiados();

                    // al cliente del view-model le asigna el los parametros del item
                    clifi.Cliente = new Cliente { Id = item.Id, Nombre = item.Nombre, Autorizado_fiado = item.Autorizado_fiado, Rut = item.Rut };
                    clifi.ListaFiados = new List<Fiado>();

                    // Abre conexión y trae todos los fiados con el procedure, pasandole el rut
                    OracleConnection _connObj = new OracleConnection(_connstring);
                    _connObj.Open();
                    OracleCommand _comObj = _connObj.CreateCommand();
                    _comObj.CommandText = "PKG_FIADO.SP_S_FIADOS_RUT";
                    _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                    OracleParameter _RutParam = new OracleParameter();
                    _RutParam.ParameterName = "rutCliente";
                    _RutParam.OracleDbType = OracleDbType.Varchar2;
                    _RutParam.Direction = System.Data.ParameterDirection.Input;
                    _RutParam.Value = item.Rut;
                    _comObj.Parameters.Add(_RutParam);


                    OracleParameter _RefParam = new OracleParameter();
                    _RefParam.ParameterName = "fiadoCur";
                    _RefParam.OracleDbType = OracleDbType.RefCursor;
                    _RefParam.Direction = System.Data.ParameterDirection.Output;
                    _comObj.Parameters.Add(_RefParam);
                    OracleDataReader _rdrObj = _comObj.ExecuteReader();

                    // Si encontró el rut, va a buscar los elementos
                    if (_rdrObj.HasRows)
                    // Si el cursor devolvió elementos, lo fetchea, insertando en el view-model cada fiado que encuentra
                    {
                        while (_rdrObj.Read())
                        {
                            Fiado f = new Fiado
                            {
                                IdFiado = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("ID_FIADO")),
                                MontoSolicitado = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("MONTO_SOLICITADO")),
                                MontoPagado = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("MONTO_PAGADO")),
                                FechaCompra = _rdrObj.GetDateTime(_rdrObj.GetOrdinal("FECHA_COMPRA")),
                                FechaPago = _rdrObj.GetDateTime(_rdrObj.GetOrdinal("FECHA_PAGO")),
                                EstadoPago = _rdrObj.GetString(_rdrObj.GetOrdinal("ESTADO_PAGO")),
                                IdBoleta = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("ID_BOLETA")),
                                IdCliente = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("ID_CLIENTE"))

                            };
                            if (!(f.EstadoPago.Equals("1")))
                            {
                                clifi.ListaFiados.Add(f);
                            }
                            
                        }
                    }

                    _connObj.Close();
                    _connObj.Dispose();
                    _connObj = null;

                    // clifi es el view-model (por si no recuerdas de mas arriba), se lo pasamos a una lista de viewmodels que creamos al inicio.
                    // El proceso se repetira por cada cliente que exista.
                    listaClientesFiados.Add(clifi);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
            // Si todo salió bien, deberíamos obtener un listado de view-model ClienteFiado
            // Esto puede parecer extraño pero, en la práctica, es un List de ClienteFiado, que es un Cliente + un List de fiados XDDDDD
            // Valió la pena estudiar MVC
            return listaClientesFiados;
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_CLIENTES.SP_S_CLIENTES";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "cliCur";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = System.Data.ParameterDirection.Output;
                _comObj.Parameters.Add(_RefParam);
                OracleDataReader _rdrObj = _comObj.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        listaClientes.Add(new Cliente
                        {
                            Id = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_CLIENTE")),
                            Rut = _rdrObj.GetString(_rdrObj.GetOrdinal("RUT_CLIENTE")),
                            Nombre = _rdrObj.GetString(_rdrObj.GetOrdinal("NOMBRE")),
                            Autorizado_fiado = (long)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("AUTORIZADO_FIADO"))
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

            return listaClientes;
        }

        public bool pagarFiado(int idFiado, string estadoFiado)
        {
            var db = new YuyosEntities(); //Instancia DB
            try
            {
                DateTime now = DateTime.Now;
                db.SP_U_PAGAR_FIADO(idFiado, estadoFiado, now);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }

    
}