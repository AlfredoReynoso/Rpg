using Rpg.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rpg.Controllers
{
    public class PersonajesController : BaseController
    {
        private readonly RPGContext db;

        public ActionResult Index()
        {
            using (var db = new RPGContext())
            {
                var personajes = db.Personajes.ToList();
                return View(personajes);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ElegirPErsonaje(int id)
        {
            using (var db = new RPGContext())
            {
                var personajeElegido = db.Personajes.Find(id);
                Session["PersonajeElegido"] = personajeElegido.Nombre;
                Session["PersonajeId"] = personajeElegido.Id;
            }

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult Create(string nombre)
        {
            using (var db = new RPGContext())
            {
                var nuevoPersonaje = new Personajes
                {
                    Nombre = nombre,
                    Nivel = 1,
                    Oro = 100
                };
                db.Personajes.Add(nuevoPersonaje);
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }
    }
}