using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanCareBack.Models;
using UrbanCareBack.Services;

namespace UrbanCareBack.Controllers
{
    [Route("/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class InsigniaController : ControllerBase
    {
        private readonly InsigniaService _insigniaService;

        public InsigniaController(InsigniaService insigniaService)
        {
            _insigniaService = insigniaService;
        }   

        [HttpGet("/descargar")]
        public IActionResult DescargarCertificado(string nombreEvento, string nombreParticipante)
        {
            var htmlCertificado = _insigniaService.GenerarPlantillaCertificado("plantillaHTML", nombreEvento, nombreParticipante, DateTime.Now);
            var pdfBytes = _insigniaService.ConvertirHtmlAPdf(htmlCertificado);

            return File(pdfBytes, "application/pdf", "certificado.pdf");
        }
    }
}
