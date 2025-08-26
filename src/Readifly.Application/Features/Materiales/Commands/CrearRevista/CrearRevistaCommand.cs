using MediatR;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;

namespace Readifly.Application.Features.Materiales.Commands.CrearRevista
{
    public class CrearRevistaCommand : IRequest<Result<RevistaDto>>
    {
        public string ISBN { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
        public int Numero { get; set; }
        public int Volumen { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
