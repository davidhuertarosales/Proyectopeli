using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Proyectopeli.Models
{
    public class Peliculadb : DbContext
    {
        public Peliculadb() : base()
        {
            this.Database.CommandTimeout = 180;
        }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
    }
}