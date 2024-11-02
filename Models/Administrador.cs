using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models
{
    public class Administrador
    {
        [Key]
        public int IdAdministrador { get; set; }

        [Required]
        [StringLength(25)]
        public required string Username { get; set; }

        [Required]
        [StringLength(255)]
        public required string Password { get; set; }
    }
}
