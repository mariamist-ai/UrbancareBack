using DinkToPdf;
using DinkToPdf.Contracts;

namespace UrbanCareBack.Services{
    public class InsigniaService{
        private readonly IConverter _pdfConverter;

        public InsigniaService(IConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        public string GenerarPlantillaCertificado(string plantilla, string nombreEvento, string nombreParticipante, DateTime fechaEvento)
        {
            return plantilla.Replace("{{nombreEvento}}", nombreEvento)
                            .Replace("{{nombreParticipante}}", nombreParticipante)
                            .Replace("{{fechaEvento}}", fechaEvento.ToString("dd/MM/yyyy"));
        }

        public byte[] ConvertirHtmlAPdf(string htmlCertificado)
        {
            var pdfDoc = new HtmlToPdfDocument
            {
                GlobalSettings = new GlobalSettings
                {
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = { new ObjectSettings { HtmlContent = htmlCertificado } }
            };

            return _pdfConverter.Convert(pdfDoc); 
        }
    }
}