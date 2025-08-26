using MediatR;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;

namespace Readifly.Application.Features.Materiales.Commands.CrearLibro
{
    public class CrearLibroCommand : IRequest<Result<LibroDto>>
    {
        public string ISBN { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int NumeroPaginas { get; set; }
        public string Editorial { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
    }
}
