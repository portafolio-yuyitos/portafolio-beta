using Oracle.ManagedDataAccess.Client;
using portafolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portafolio.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: Proveedores
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                List<Proveedor> provs = new List<Proveedor>();

                String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
                try
                {
                    OracleConnection _connObj = new OracleConnection(_connstring);
                    _connObj.Open();
                    OracleCommand _comObj = _connObj.CreateCommand();
                    _comObj.CommandText = "PKG_PROVEEDORES.SP_S_PROVEEDORES";
                    _comObj.CommandType = System.Data.CommandType.StoredProcedure;

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
                            provs.Add(new Proveedor
                            {
                                IdProveedor = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("ID_PROVEEDOR")),
                                RutProveedor = _rdrObj.GetString(_rdrObj.GetOrdinal("RUT_PROVEEDOR")),
                                Email = _rdrObj.GetString(_rdrObj.GetOrdinal("EMAIL")),
                                Fono = (long)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("FONO")),
                                Giro = _rdrObj.GetString(_rdrObj.GetOrdinal("GIRO")),
                                RazonSocial = _rdrObj.GetString(_rdrObj.GetOrdinal("RAZON_SOCIAL"))

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

                return View(provs);
            }
            return Redirect("~/Login/");
        }

        [HttpPost]
        public bool Agregar(Proveedor pro)
        {
            var db = new Entities(); //Instancia DB
            try
            {
                db.SP_I_PROVEEDOR(pro.RutProveedor,pro.RazonSocial,pro.Fono,pro.Email,pro.Giro);
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
                db.SP_D_PROVEEDOR(rut);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        public bool Update(Proveedor pro)
        {
            var db = new Entities(); //Instancia DB
            try
            {
                db.SP_U_PROVEEDOR(pro.RutProveedor,pro.RazonSocial,pro.Fono,pro.Email,pro.Giro);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        public JsonResult Proveedores()
        {
            List<Proveedor> provs = new List<Proveedor>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_PROVEEDORES.SP_S_PROVEEDORES";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

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
                        provs.Add(new Proveedor
                        {
                            IdProveedor = (int)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("ID_PROVEEDOR")),
                            RutProveedor = _rdrObj.GetString(_rdrObj.GetOrdinal("RUT_PROVEEDOR")),
                            Email = _rdrObj.GetString(_rdrObj.GetOrdinal("EMAIL")),
                            Fono = (long)_rdrObj.GetDecimal(_rdrObj.GetOrdinal("FONO")),
                            Giro = _rdrObj.GetString(_rdrObj.GetOrdinal("GIRO")),
                            RazonSocial = _rdrObj.GetString(_rdrObj.GetOrdinal("RAZON_SOCIAL"))

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
                Data = provs,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };

        }
    }
}