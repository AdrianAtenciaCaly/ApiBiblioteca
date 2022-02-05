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
    public class UsuarioController : Controller
    {
        private readonly AplicationDbContext _context;
        public UsuarioController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listUsuarios = await _context.Usuario.ToListAsync();
                return Ok(listUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody] Usuario usuario)
        {
            try
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El Usuario  fue registrado con exito!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (id != usuario.id)
                {
                    return NotFound();
                }
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario actualizado ccon exito!" });
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
                var usuario = await _context.Usuario.FindAsync(id);
                if (id != usuario.id)
                {
                    return NotFound();
                }
                _context.Remove(usuario);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Usuario eliminado  con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}