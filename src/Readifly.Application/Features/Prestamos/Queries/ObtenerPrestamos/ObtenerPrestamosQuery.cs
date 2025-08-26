using MediatR;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;

namespace Readifly.Application.Features.Prestamos.Queries.ObtenerPrestamos
{
    public class ObtenerPrestamosQuery : IRequest<Result<IEnumerable<PrestamoDto>>>
    {
        public string? UsuarioId { get; set; }
        public bool? SoloActivos { get; set; }
    }
}
