using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanCareBack.Models;
using UrbanCareBack.Services;

namespace UrbanCareBack.Controllers
{
    [Route("/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly ColaboradoresService _colaboradoresService;

        public ColaboradorController(ColaboradoresService colaboradoresService)
        {
            _colaboradoresService = colaboradoresService;
        }

        [HttpPost("agregar")]
        public async Task<ActionResult<Colaborador>> AgregarColaborador(Colaborador colaborador)
        {
            await _colaboradoresService.AgregarColaborador(colaborador);
            return CreatedAtAction(nameof(ObtenerColaborador), new { id = colaborador.IdColaborador }, colaborador);
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> ListarColaboradores()
        {
            var organizacionId = User.Claims.FirstOrDefault(c => c.Type == "OrganizacionId")?.Value;

            if (organizacionId == null)
            {
                return Unauthorized("No se pudo identificar la organización.");
            }
            var colaboradores = await _colaboradoresService.ListarColaboradoresPorOrganizacion(int.Parse(organizacionId));
            
            return Ok(colaboradores);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Colaborador>> ObtenerColaborador(int id)
        {
            var colaborador = await _colaboradoresService.ObtenerColaboradorPorId(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            return Ok(colaborador);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> EditarColaborador(int id, Colaborador colaborador)
        {
            if (id != colaborador.IdColaborador)
            {
                return BadRequest();
            }
            await _colaboradoresService.ActualizarColaborador(colaborador);
            return NoContent();
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarColaborador(int id)
        {
            var colaborador = await _colaboradoresService.ObtenerColaboradorPorId(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            await _colaboradoresService.EliminarColaborador(id);
            return NoContent();
        }
    }
}
