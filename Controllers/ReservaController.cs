using ApiBiblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly AplicationDbContext _context;
        public ReservaController(AplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listReservas= await _context.Reserva.ToListAsync();
                return Ok(listReservas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody] Reserva reserva)
        {
            try
            {
                _context.Reserva.Add(reserva);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La Reserva fue registrado con exito!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Reserva reserva)
        {
            try
            {
                if (id != reserva.id)
                {
                    return NotFound();
                }
                _context.Entry(reserva).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Reserva se actualizo  con exito!" });
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
                var reserva = await _context.Reserva.FindAsync(id);
                if (id != reserva.id)
                {
                    return NotFound();
                }
                _context.Remove(reserva);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Reserva  eliminada  con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}