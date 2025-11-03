using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rpg.Models
{
    public class RPGContext : DbContext
    {
        public RPGContext()
       : base("RPG")
        {
        }

        public DbSet<Personajes> Personajes { get; set; }

        public DbSet<cat_items> CatItems { get; set; }

        public DbSet<Inventario> Inventario { get; set; }

    }
}