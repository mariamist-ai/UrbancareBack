using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using UrbanCareBack.Custom;
using UrbanCareBack.Models;
using UrbanCareBack.Dto;
using UrbanCareBack.Data;
using System.Security.Claims;

namespace UrbanCareBack.Controllers{
    [Route("/[controller]")]
    [AllowAnonymous]
    [ApiController]
        public class AccesoController : ControllerBase{
        private readonly UrbanCareDbContext _context;
        private readonly Utilidades _utilidades;
        public AccesoController(UrbanCareDbContext context, Utilidades utilidades) { 
            _context =  context;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("registrarOrg")]
        public async Task<IActionResult> RegistrarOrg(Organizacion organizacion)
        {
            organizacion.Password = _utilidades.encriptarSHA256(organizacion.Password);

            await _context.Organizaciones.AddAsync(organizacion);
            await _context.SaveChangesAsync();

            if (organizacion.IdOrganizacion != 0){
                return StatusCode(StatusCodes.Status200OK, new { Estado = "Organizacion registrada correctamente" });
            }
            else{
                return StatusCode(StatusCodes.Status200OK, new { Estado = "La organizacion no pudo registrarse" });
            }
        }

        [HttpPost]
        [Route("registrarAdmin")]
        public async Task<IActionResult> RegistrarAdm(Administrador administrador)
        {
            administrador.Password = _utilidades.encriptarSHA256(administrador.Password);

            await _context.Administradores.AddAsync(administrador);
            await _context.SaveChangesAsync();

            if (administrador.IdAdministrador != 0){
                return StatusCode(StatusCodes.Status200OK, new { Estado = "Administrador registrado correctamente" });
            }
            else{
                return StatusCode(StatusCodes.Status200OK, new { Estado = "El administrador no pudo registrarse" });
            }
        }

        [HttpPost]
        [Route("Ingresar")]
        public async Task<IActionResult> Ingresar(LoginDto objeto)
        {
            var organizacion = await _context.Organizaciones
                .Where(u => u.Username == objeto.Username && u.Password == _utilidades.encriptarSHA256(objeto.Password))
                .FirstOrDefaultAsync();

            if (organizacion != null)
            {
                var token = _utilidades.generarTokenJwt(organizacion);
                return StatusCode(StatusCodes.Status200OK, new { Estado = "El token fue generado", token, rol = "Organizacion" });
            }

            var administrador = await _context.Administradores
                .Where(u => u.Username == objeto.Username && u.Password == _utilidades.encriptarSHA256(objeto.Password))
                .FirstOrDefaultAsync();

            if (administrador != null)
            {
                var token = _utilidades.generarTokenJwt(administrador);
                return StatusCode(StatusCodes.Status200OK, new { Estado = "El token fue generado", token, rol = "Administrador" });
            }

            return StatusCode(StatusCodes.Status200OK, new { Estado = "El token no fue generado" });
        }

        [HttpGet]
        [Route("usuarioActual")]  
        public async Task<IActionResult> ObtenerUsuarioActual()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var rol = User.FindFirstValue("rol");

            if (rol == "Organizacion")
            {
                var organizacion = await _context.Organizaciones.FindAsync(int.Parse(userId!));
                if (organizacion != null)
                {
                    return Ok(new { Tipo = "Organizacion", Datos = organizacion });
                }
            }
            else if (rol == "Administrador")
            {
                var administrador = await _context.Administradores.FindAsync(int.Parse(userId!));
                if (administrador != null)
                {
                    return Ok(new { Tipo = "Administrador", Datos = administrador });
                }
            }

            return NotFound("Usuario no encontrado");
        }
    }
}