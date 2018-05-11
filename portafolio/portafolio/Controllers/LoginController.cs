using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Objects;

namespace portafolio.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public bool ValidaUsuario(string nombre, string pass)
        {
            var db = new Entities(); //Instancia DB
            ObjectParameter existe = new ObjectParameter("EXISTE", typeof(string));
            db.SP_S_VALIDAUSUARIO(nombre,pass,existe);

            if (existe.Value.ToString().Trim().ToLower().Equals("no"))
            {
                return false;
            }
            Session["usuario"] = nombre;
            return true;
        }
    }
}