using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanCareBack.Data;
using UrbanCareBack.Models;
using UrbanCareBack.Services;

namespace UrbanCareBack.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly AdministradorService _administradorService;

        public AdministradorController(AdministradorService administradorService)
        {
            _administradorService = administradorService;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradores()
        {
            var administradores = await _administradorService.ListarTodosAdmin();
            return Ok(administradores);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            var administrador = await _administradorService.ObtenerAdministradorPorId(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return Ok(administrador);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
        {
            await _administradorService.AgregarAdministrador(administrador);
            return CreatedAtAction(nameof(GetAdministrador), new { id = administrador.IdAdministrador }, administrador);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> PutAdministrador(int id, Administrador administrador)
        {
            if (id != administrador.IdAdministrador)
            {
                return BadRequest();
            }

            await _administradorService.ActualizarAdministrador(administrador);
            return NoContent();
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            var administrador = await _administradorService.ObtenerAdministradorPorId(id);
            if (administrador == null)
            {
                return NotFound();
            }

            await _administradorService.EliminarAdministrador(id);
            return NoContent();
        }
    }
}
