using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;

public class Insignia
{
    [Key]
    public int IdInsignia { get; set; }
    
    [Required]
    [StringLength(65)]
    public required string NombreInsignia { get; set; }

    [Required]
    [StringLength(500)]
    public required string Descripcion { get; set; }

    public int EventoId { get; set; }
    public int ParticipanteId { get; set; }
    
    public required Participacion Participacion { get; set; }

    [StringLength(500)]
    public string? UrlCertificado { get; set; }
}