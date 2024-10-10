using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;

public class TipoDoc
{
    [Key]
    public int IdTipoDoc { get; set; }
    public required string Nombre { get; set; }
}