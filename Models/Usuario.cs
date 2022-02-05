using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBiblioteca.Models
{
    public class Usuario
    {
        public int id { get; set; }
        [Required]
        public string names { get; set; }

        [Required]
        public string surnames { get; set; }
   
    }
}
