using MediatR;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;

namespace Readifly.Application.Features.Prestamos.Commands.RealizarPrestamo
{
    public class RealizarPrestamoCommand : IRequest<Result<PrestamoDto>>
    {
        public string ISBN { get; set; } = string.Empty;
        public string UsuarioId { get; set; } = string.Empty;
    }
}
