using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}