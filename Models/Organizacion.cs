using System.ComponentModel.DataAnnotations;

namespace UrbanCareBack.Models;

public class Organizacion
{
    [Key]
    public int IdOrganizacion { get; set; }
    public required string NombreOrg { get; set; }
    public required string Ruc { get; set; }
    public required string Celular { get; set; }
    public required string Correo { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }

    public int AdministradorId { get; set; }
    public required Administrador Administrador { get; set; }

    // Propiedad de navegación para los colaboradores
    public ICollection<Colaborador> Colaboradores { get; set; } = new List<Colaborador>();

    // Propiedad de navegación para los eventos
    public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}