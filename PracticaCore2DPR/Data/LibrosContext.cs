using Microsoft.EntityFrameworkCore;
using PracticaCore2DPR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Data
{
    public class LibrosContext : DbContext
    {

        public LibrosContext(DbContextOptions<LibrosContext> options) : base(options)
        {

        }

        public DbSet<Libro> libros { get; set; }
        public DbSet<Genero> generos { get; set; }
        public DbSet<Pedido> pedidos { get; set; }

        public DbSet<User> usuarios { get; set; }

        public DbSet<VistaPedidos> vistaPedidos { get; set; }
    }
}
