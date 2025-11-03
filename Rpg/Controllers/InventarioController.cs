using Rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rpg.Controllers
{
    public class InventarioController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new RPGContext())
            {
                Session["PersonajeId"] = "1";

                var listaInventario = db.Inventario.ToList();

                return View(listaInventario);
            }

            
        }
    }
}