using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UrbanCareBack.Models{
    public class Participante
    {
        [Key]
        public int IdParticipante { get; set; }
        
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string? NumDoc { get; set; }
        public string? Celular { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        // Clave foránea para TipoDoc
        public int? TipoDocId { get; set; }

        // Relación con TipoDoc
        [JsonIgnore]
        public TipoDoc? TipoDoc { get; set; }

        // Propiedad de navegación para las participaciones
        [JsonIgnore]
        public ICollection<Participacion> Participaciones { get; set; } = new List<Participacion>();
    }
}

