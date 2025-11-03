using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rpg.Models
{
    public class Personajes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Nivel { get; set; }

        public int Oro { get; set; }
    }
}