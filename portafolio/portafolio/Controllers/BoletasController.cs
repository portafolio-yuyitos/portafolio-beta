using Oracle.ManagedDataAccess.Client;
using portafolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portafolio.Controllers
{
    public class BoletasController : Controller
    {
        // GET: Boletas
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                return View();
            }
            return Redirect("~/Login/");


            
        }

        public JsonResult ObtenerBoletas()
        {
            // Creamos lista de boletas
            var boletas = new List<Boleta>();
            
            

            return new JsonResult()
            {
                Data = boletas,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };


        }


        // ###########################
        //      DEVUELVE PEDIDOS
        // ###########################
        public List<Boleta> ObtenerPedidos()
        {
            List<Boleta> boletas = new List<Boleta>();

            String _connstring = "DATA SOURCE=localhost:1521/xe;USER ID=YUYOS;Password=cipres;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _comObj = _connObj.CreateCommand();
                _comObj.CommandText = "PKG_BOLETA.SP_S_BOLETA";
                _comObj.CommandType = System.Data.CommandType.StoredProcedure;

                /*OracleParameter _IdProvParam = new OracleParameter();
                _IdProvParam.ParameterName = "idProveedor";
                _IdProvParam.OracleDbType = OracleDbType.Int32;
                _IdProvParam.Direction = System.Data.ParameterDirection.Input;
                _IdProvParam.Value = idProveedor;
                _comObj.Parameters.Add(_IdProvParam);*/

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
                        boletas.Add(new Boleta
                        {
                            NumeroBoleta = _rdrObj.GetInt32(_rdrObj.GetOrdinal("NUMERO_BOLETA")),
                            Fiado = _rdrObj.GetInt32(_rdrObj.GetOrdinal("FIADO")),
                            TipoPago = _rdrObj.GetString(_rdrObj.GetOrdinal("TIPO_PAGO")),
                            TotalBoleta = _rdrObj.GetInt32(_rdrObj.GetOrdinal("TOTAL_BOLETA")),
                            FechaBoleta = _rdrObj.GetDateTime(_rdrObj.GetOrdinal("FECHA_PAGO")),
                            IdCliente = _rdrObj.GetInt32(_rdrObj.GetOrdinal("ID_CLIENTE"))
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

            return boletas;
        }
    }
}