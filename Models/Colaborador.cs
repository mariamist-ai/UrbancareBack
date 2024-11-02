using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UrbanCareBack.Models;

public class Colaborador
{
    [Key]
    public int IdColaborador { get; set; }

    [Required]
    [StringLength(20)]
    public required string Nombre { get; set; }

    [Required]
    [StringLength(35)]
    public required string Apellido { get; set; }

    [Required]
    [StringLength(10)]
    public required string TipoDoc { get; set; }

    [Required]
    [StringLength(9)]
    public required string NumDoc { get; set; }

    [Required]
    [StringLength(9)]
    public required string Celular { get; set; }

    [Required]
    [StringLength(10)]
    public required string TipoColaborador { get; set; }

    [Required]
    [StringLength(50)]
    public required string Correo { get; set; }

    public int OrganizacionId { get; set; }

    [JsonIgnore]
    public Organizacion? Organizacion { get; set; }
}