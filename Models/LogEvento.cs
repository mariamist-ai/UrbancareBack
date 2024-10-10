using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;

public class LogEvento
{
    [Key]
    public int IdLogEvento { get; set; }
    public bool Estado { get; set; }
    public required string Fecha { get; set; }
    public required string Hora { get; set; }

    // Propiedad de navegación para la colección de eventos
    public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}