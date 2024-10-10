using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;

public class Administrador
{
    [Key]
    public int IdAdministrador { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}