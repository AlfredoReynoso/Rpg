using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rpg.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var nombre = Session["PersonajeElegido"] as string;
            ViewBag.NombrePersonaje = nombre;

            var id = Session["PersonajeId"] as string;
            ViewBag.IdPersonaje = id;

        }
    }
}