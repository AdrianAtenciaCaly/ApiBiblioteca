using ApiBiblioteca.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

using System.Linq;
using System.Threading.Tasks;

namespace ApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : Controller
    {

        private readonly AplicationDbContext _context;
        public LibroController(AplicationDbContext context)
        {
            _context = context;
        }
     

       [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listLibros = await _context.Libro.ToListAsync();
                return Ok(listLibros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var listLibros = await _context.Libro.FindAsync(id);
                return Ok(listLibros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> post([FromBody] Libro libro)
        {
            try
            {
                _context.Libro.Add(libro);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El libro fue registrado con exito!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            try
            {
                var listLibros = await _context.Libro.FindAsync(id);
                if (listLibros == null)
                {
                    return NotFound();
                }
                listLibros.reserve_status = !listLibros.reserve_status;
                _context.Entry(listLibros).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Libro actualizado ccon exito!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
       
        
       
           
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var libro = await _context.Libro.FindAsync(id);
                if (id != libro.id)
                {
                    return NotFound();
                }           
                _context.Remove(libro);
                await _context.SaveChangesAsync();
               
                return Ok(new { message = "Libro eliminado  con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}


