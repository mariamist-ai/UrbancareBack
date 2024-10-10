using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;

public class Insignia
{
    [Key]
    public int IdInsignia { get; set; }
    public required string NombreInsignia { get; set; }
    public required string Descripcion { get; set; }

    public int EventoId { get; set; }
    public int ParticipanteId { get; set; }
    
    public required Participacion Participacion { get; set; }
}