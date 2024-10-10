namespace UrbanCareBack.Dto
{
    public class ParticipanteDto
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string? NumDoc { get; set; }
        public string? Celular { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public int? TipoDocId { get; set; }
    }
}