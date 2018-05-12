using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Objects;
using portafolio.Models;

namespace portafolio.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                return View();
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
    }
}