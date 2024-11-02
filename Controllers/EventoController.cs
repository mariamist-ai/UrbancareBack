using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanCareBack.Models;
using UrbanCareBack.Services;

namespace UrbanCareBack.Controllers
{
    [Route("/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly EventoService _eventoService;

        public EventoController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost("agregar")]
        public async Task<ActionResult<Evento>> AgregarEvento(Evento evento)
        {
            await _eventoService.AgregarEvento(evento);
            return CreatedAtAction(nameof(ObtenerEvento), new { id = evento.IdEvento }, evento);
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Evento>>> ListarEvento()
        {
            var organizacionId = User.Claims.FirstOrDefault(c => c.Type == "OrganizacionId")?.Value;

            if (organizacionId == null)
            {
                return Unauthorized("No se pudo identificar la organización.");
            }
            var eventos = await _eventoService.ListarEventosPorOrganizacion(int.Parse(organizacionId));
            
            return Ok(eventos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Evento>> ObtenerEvento(int id)
        {
            var evento = await _eventoService.ObtenerEventoPorId(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> EditarEvento(int id, Evento evento)
        {
            if (id != evento.IdEvento)
            {
                return BadRequest();
            }
            await _eventoService.ActualizarEvento(evento);
            return NoContent();
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarEvento(int id)
        {
            var evento = await _eventoService.ObtenerEventoPorId(id);
            if (evento == null)
            {
                return NotFound();
            }
            await _eventoService.EliminarEvento(id);
            return NoContent();
        }
    }
}
