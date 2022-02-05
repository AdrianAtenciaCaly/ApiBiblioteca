using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBiblioteca.Models
{
    public class Reserva
    {
        public int id { get; set; }

        public int idLibro { get; set; }
        public int IdUsuario { get; set; } 
    }
}
