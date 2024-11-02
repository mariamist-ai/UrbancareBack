using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;

public class Participacion
{
    [Key]
    public int EventoId { get; set; }
    public required Evento Evento { get; set; }

    public int ParticipanteId { get; set; }
    public required Participante Participante { get; set; }

    [DataType(DataType.Date)] //solo toma la fecha YYYY/MM/DD
    public required DateTime FechaInscripcion { get; set; }

    public required TimeSpan HoraInscripcion { get; set; }

    public ICollection<Insignia> Insignias { get; set; } = new List<Insignia>();
}