using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBiblioteca.Models
{
    public class Libro
    {
        public int id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string title { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string author { get; set; }
        [Required]
        public int   release_date { get; set; }

        [Required]
        public bool reserve_status { get; set; }
    }
}
