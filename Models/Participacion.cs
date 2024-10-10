using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;

public class Participacion
{
    [Key]
    public int EventoId { get; set; }
    public required Evento Evento { get; set; }

    public int ParticipanteId { get; set; }
    public required Participante Participante { get; set; }

    public required string FechaInscripcion { get; set; }
    public required string HoraInscripcion { get; set; }

    // Propiedad de navegación para las insignias
    public ICollection<Insignia> Insignias { get; set; } = new List<Insignia>();
}