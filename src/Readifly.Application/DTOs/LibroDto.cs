namespace Readifly.Application.DTOs
{
    public class LibroDto : MaterialBibliograficoDto
    {
        public string Autor { get; set; } = string.Empty;
        public int NumeroPaginas { get; set; }
        public string Editorial { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
    }
}
