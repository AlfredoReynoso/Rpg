using Rpg.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rpg.Controllers
{
    public class TiendaController : BaseController
    {
        private readonly RPGContext db;

        public ActionResult Index()
        {
            using (var db = new RPGContext())
            {
                var personajeIdObj = Session["PersonajeId"];
                
                if (personajeIdObj == null)
                {
                    return RedirectToAction("Index", "Personajes");
                }
                
                int personajeId = (int)personajeIdObj;

                ViewBag.Oro = db.Personajes
                    .Where(p => p.Id == personajeId)
                    .Select(p => p.Oro)
                    .FirstOrDefault();

               var items = db.CatItems.ToList();
               return View(items);
            }
        }

        [HttpPost]
        public ActionResult Comprar(int itemId)
        {
            using (var db = new RPGContext())
            {
                var costo = db.CatItems
                    .Where(p => p.Id == itemId)
                    .Select(p => p.Costo)
                    .FirstOrDefault();
                    
                if (costo == null)
                {
                    return View(); 
                }
                    

                var personajeIdObj = Session["PersonajeId"];
                
                if (personajeIdObj == null)
                {
                    return RedirectToAction("Index", "Personajes");
                }

                int personajeId = (int)personajeIdObj;
                var paramId = new SqlParameter("@id", personajeId);
                var paramCosto = new SqlParameter("@costo", costo);
                var idItem = new SqlParameter("@id_item", itemId);

                db.Database.ExecuteSqlCommand(
                    "EXEC Sp_Tienda_Compra @id, @costo, @id_item", paramId, paramCosto, idItem);

                var oro = db.Personajes
                    .Where(p => p.Id == personajeId)
                    .Select(p => p.Oro)
                    .FirstOrDefault();

                ViewBag.Oro = oro;
                return RedirectToAction("Index");
            }
        }




    }
}