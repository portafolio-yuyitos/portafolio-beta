﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portafolio.Controllers
{
    public class OrdenPedidoController : Controller
    {
        // GET: OrdenPedido
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