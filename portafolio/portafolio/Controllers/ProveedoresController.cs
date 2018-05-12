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
                return View();
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
    }
}