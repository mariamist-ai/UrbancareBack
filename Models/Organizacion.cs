using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UrbanCareBack.Models
{
    public class Organizacion
    {
        [Key]
        public int IdOrganizacion{ get; set; }

        [Required]
        [StringLength(35)]
        public required string NombreOrg { get; set; }

        [Required]
        [StringLength(11)]
        public required string Ruc { get; set; }

        [Required]
        [StringLength(25)]
        public required string Username { get; set; }

        [Required]
        [StringLength(255)]
        public required string Password { get; set; }

        [Required]
        [StringLength(9)]
        public required string Celular { get; set; }

        public int AdministradorId { get; set; }

        [JsonIgnore]
        public Administrador? Administrador { get; set; }

        [JsonIgnore]
        public ICollection<Colaborador> Colaboradores { get; set; } = new List<Colaborador>();

        [JsonIgnore]
        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
