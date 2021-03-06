﻿using System;
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
                                Autorizado_fiado = (long)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("AUTORIZADO_FIADO")),
                                Estado = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("ESTADO"))
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
        public string Agregar(Cliente cli)
        {
            var db = new YuyosEntities(); //Instancia DB
            ObjectParameter salida = new ObjectParameter("v_SALIDA", -1);

            try
            {
                db.SP_I_CLIENTE(cli.Rut, cli.Nombre, 1, salida);

                return salida.Value.ToString();
            }
            catch (Exception e)
            {
                return "Error";
            }
        }

        [HttpPost]
        public bool Eliminar(string rut)
        {
            var db = new YuyosEntities(); //Instancia DB
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
            var db = new YuyosEntities(); //Instancia DB
            try
            {
                db.SP_U_CLIENTE(cli.Rut,cli.Nombre,cli.Estado);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        public bool Autorizar(Cliente cli)
        {
            var db = new YuyosEntities(); //Instancia DB
            try
            {
                db.SP_AUTORIZAR_CLIENTE(cli.Rut,cli.Autorizado_fiado);
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
            try
            {
                clientes = ClientesList();
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

        [HttpPost]
        public List<Cliente> ClientesList()
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

            return clientes;
        }
    }
}