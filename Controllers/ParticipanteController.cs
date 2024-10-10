using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanCareBack.Data;
using UrbanCareBack.Models;
using UrbanCareBack.Services;

namespace UrbanCareBack.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly ParticipanteServices _participanteServices;

        public ParticipanteController(ParticipanteServices participanteServices)
        {
            _participanteServices = participanteServices;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Participante>>> ListarParticipantes()
        {
            var participantes = await _participanteServices.ListarTodosParticipante();
            return Ok(participantes);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Participante>> ObtenerParticipante(int id)
        {
            var participante = await _participanteServices.ObtenerParticipantePorId(id);

            if (participante == null)
            {
                return NotFound();
            }

            return Ok(participante);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Participante>> GuardarParticipante(Participante participante)
        {
            await _participanteServices.AgregarParticipante(participante);
            return CreatedAtAction(nameof(ObtenerParticipante), new { id = participante.IdParticipante }, participante);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> EditarParticipante(int id, Participante participante)
        {
            if (id != participante.IdParticipante)
            {
                return BadRequest();
            }

            await _participanteServices.ActualizarParticipante(participante);
            return NoContent();
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarParticipante(int id)
        {
            var participante = await _participanteServices.ObtenerParticipantePorId(id);
            if (participante == null)
            {
                return NotFound();
            }

            await _participanteServices.EliminarParticipante(id);
            return NoContent();
        }
    }
}