using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;

public class TipoEvento
{
    [Key]
    public int IdTipoEvento { get; set; }
    public required string NombreEvento { get; set; }

    // Propiedad de navegación para la colección de eventos
    public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
