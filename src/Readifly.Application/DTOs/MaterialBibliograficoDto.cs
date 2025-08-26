namespace Readifly.Application.DTOs
{
    public class MaterialBibliograficoDto
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public bool EstaPrestado { get; set; }
    }
}
