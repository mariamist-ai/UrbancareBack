using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UrbanCareBack.Models{
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }
            
        [Required]
        [StringLength(45)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        public required string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public required DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public required DateTime FechaFin { get; set; }

        [Required]
        [StringLength(50)]
        public required string Ubicacion { get; set; }

        [Required]
        [StringLength(10)]
        public required string Estado { get; set; }

        [Required]
        [StringLength(35)]
        public required string TipoEvento { get; set; }

        public int OrganizacionId { get; set; }

        [JsonIgnore]
        public Organizacion? Organizacion { get; set; }

        [JsonIgnore]
        public ICollection<Participacion> Participaciones { get; set; } = new List<Participacion>();
    }
}