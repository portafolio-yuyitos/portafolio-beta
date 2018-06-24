using portafolio.Models;
using portafolio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portafolio.Controllers
{
    public class HomeController : Controller
    {
        InformesController ic = new InformesController();
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                Bienvenida bienvenida = new Bienvenida();
                bienvenida.Ultimas5Boletas = Informe5Boletas();
                bienvenida.ProductosPocoStock = ic.ProductosPorStock(1);
                return View(bienvenida);
            }
            return Redirect("~/Login/");
        }


        public List<Boleta> Informe5Boletas()
        {
            
            List<Boleta> lista = ic.Boletas30DiasList();

            return lista;
        }



    }
}