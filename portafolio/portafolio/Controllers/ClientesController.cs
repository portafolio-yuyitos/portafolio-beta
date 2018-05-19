using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Objects;
using portafolio.Models;
using Oracle.ManagedDataAccess.Client;

namespace portafolio.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                List<Cliente> clientes = new List<Cliente>();

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
                            clientes.Add(new Cliente
                            {
                                Id = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("ID_CLIENTE")),
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

                return View(clientes);
            }
            return Redirect("~/Login/");
        }

        [HttpPost]
        public bool Agregar(Cliente cli)
        {
            var db = new Entities(); //Instancia DB
            try
            {
                db.SP_I_CLIENTE(cli.Rut, cli.Nombre, 0);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        public bool Eliminar(string rut)
        {
            var db = new Entities(); //Instancia DB
            try
            {
                db.SP_D_CLIENTE(rut);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        public bool Update(Cliente cli)
        {
            var db = new Entities(); //Instancia DB
            try
            {
                db.SP_U_CLIENTE(cli.Rut,cli.Nombre);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        public JsonResult Clientes()
        {
            List<Cliente> clientes = new List<Cliente>();

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
                        clientes.Add(new Cliente
                        {
                            Id = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("ID_CLIENTE")),
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

            return new JsonResult()
            {
                Data = clientes,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
    }
}