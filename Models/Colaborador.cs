using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;


public class Colaborador
{
    [Key]
    public int IdColaborador { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string TipoDoc { get; set; }
    public required string NumDoc { get; set; }
    public required string Celular { get; set; }
    public required string Correo { get; set; }

    public int OrganizacionId { get; set; }
    public required Organizacion Organizacion { get; set; }
}