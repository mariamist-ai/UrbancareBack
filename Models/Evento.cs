using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;

public class Evento
{
    [Key]
    public int IdEvento { get; set; }
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }
    public required string FechaInicio { get; set; }
    public required string FechaFin { get; set; }
    public required string Ubicacion { get; set; }
    public required string Estado { get; set; }

    public int TipoEventoId { get; set; }
    public required TipoEvento TipoEvento { get; set; }

    public int OrganizacionId { get; set; }
    public required Organizacion Organizacion { get; set; }

    public int LogEventoId { get; set; }
    public required LogEvento LogEvento { get; set; }

    // Propiedad de navegación para participaciones
    public ICollection<Participacion> Participaciones { get; set; } = new List<Participacion>();
}