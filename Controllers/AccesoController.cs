using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using UrbanCareBack.Custom;
using UrbanCareBack.Models;
using UrbanCareBack.Dto;
using UrbanCareBack.Data;

namespace UrbanCareBack.Controllers{
    [Route("/[controller]")]
    [AllowAnonymous]// se puede acceder sin que el usuario este autorizado, debido a que es el login 
    [ApiController]
    public class AccesoController : ControllerBase{
        private readonly UrbanCareDbContext _context;
        private readonly Utilidades _utilidades;
        public AccesoController(UrbanCareDbContext context, Utilidades utilidades) { 
            _context =  context;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar(ParticipanteDto objeto){
            var modeloParticipante =  new Participante{
                Nombre = objeto.Nombre,
                Apellido = objeto.Apellido,
                Celular = objeto.Celular,
                NumDoc = objeto.NumDoc,
                TipoDocId = objeto.TipoDocId,
                Username = objeto.Username,
                Password = _utilidades.encriptarSHA256(objeto.Password)
            };

            await _context.Participantes.AddAsync(modeloParticipante);//se agrega de manera asincrona el usuario
            await _context.SaveChangesAsync();

            if(modeloParticipante.IdParticipante != 0){
                return StatusCode(StatusCodes.Status200OK, new {Estado = "usuario registrado correctamente"});
            } else{
                return StatusCode(StatusCodes.Status200OK, new {Estado = "El usuario no pudo registrarse"});
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto objeto){
            var usuarioEncontrado = await _context.Participantes.Where(u => u.Username == objeto.Username && u.Password == _utilidades.encriptarSHA256(objeto.Password)).FirstOrDefaultAsync();

            if(usuarioEncontrado == null){
                return StatusCode(StatusCodes.Status200OK, new {Estado = "El token no fue generado", token = ""});
            } else{
                return StatusCode(StatusCodes.Status200OK, new {Estado = "El token fue generado", token = _utilidades.generarTokenJwt(usuarioEncontrado)});
            }
        }
    }
}