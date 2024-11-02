using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UrbanCareBack.Custom;
using UrbanCareBack.Data;
using UrbanCareBack.Models;
using UrbanCareBack.Services;

namespace UrbanCareBack.Controllers
{
    [Route("/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class OrganizacionController : ControllerBase
    {
        private readonly OrganizacionService _organizacionService;

        public OrganizacionController(OrganizacionService organizacionService)
        {
            _organizacionService = organizacionService;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Organizacion>>> ListarOrganizaciones()
        {
            var organizaciones = await _organizacionService.ListarOrganizaciones();
            return Ok(organizaciones);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Organizacion>> ObtenerOrganizacion(int id)
        {
            var organizacion = await _organizacionService.ObtenerOrganizacionPorId(id);

            if (organizacion == null)
            {
                return NotFound();
            }

            return Ok(organizacion);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> EditarOrganizacion(int id, Organizacion organizacion)
        {
            if (id != organizacion.IdOrganizacion)
            {
                return BadRequest();
            }

            await _organizacionService.ActualizarOrganizacion(organizacion);
            return NoContent();
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarOrganizacion(int id)
        {
            var organizacion = await _organizacionService.ObtenerOrganizacionPorId(id);
            if (organizacion == null)
            {
                return NotFound();
            }

            await _organizacionService.EliminarOrganizacion(id);
            return NoContent();
        }
    }
}
