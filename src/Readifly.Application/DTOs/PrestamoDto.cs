namespace Readifly.Application.DTOs
{
    public class PrestamoDto
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string UsuarioId { get; set; } = string.Empty;
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionProgramada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }
    }
}
