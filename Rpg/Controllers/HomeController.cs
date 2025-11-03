using Rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rpg.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //Se deja con un personaje elegido por dafual para hacer las pruebas

            using (var db = new RPGContext())
            {
                var personajeElegido = db.Personajes.Find(1);
                Session["PersonajeElegido"] = personajeElegido.Nombre;
                Session["PersonajeId"] = personajeElegido.Id;
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}