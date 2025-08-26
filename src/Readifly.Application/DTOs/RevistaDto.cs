namespace Readifly.Application.DTOs
{
    public class RevistaDto : MaterialBibliograficoDto
    {
        public string Editorial { get; set; } = string.Empty;
        public int Numero { get; set; }
        public int Volumen { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
