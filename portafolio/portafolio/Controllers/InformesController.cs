using Oracle.ManagedDataAccess.Client;
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
                return View();
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

    }
}