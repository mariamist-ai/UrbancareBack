using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UrbanCareBack.Models
{
    public class Participante 
    {
        [Key]
        public int IdParticipante { get; set; }
        
        [Required]
        [StringLength(35)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(45)]
        public required string Apellido { get; set; }

        [Required]
        [StringLength(25)]
        public required string Username { get; set; }

        [Required]
        [StringLength(255)]
        public required string Password { get; set; }

        [Required]
        [StringLength(9)]
        public required string TipoDoc { get; set; }

        [Required]
        [StringLength(9)]
        public required string NumDoc { get; set; }

        [Required]
        [StringLength(9)]
        public required string Celular { get; set; }

        [JsonIgnore]
        public ICollection<Participacion> Participaciones { get; set; } = new List<Participacion>();
    }
}
