using ApiBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBiblioteca
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) :base (options)
        {

        }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
    }
}
