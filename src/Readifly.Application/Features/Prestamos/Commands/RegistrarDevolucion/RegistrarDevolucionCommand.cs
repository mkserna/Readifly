using MediatR;
using Readifly.Application.Common.Models;

namespace Readifly.Application.Features.Prestamos.Commands.RegistrarDevolucion
{
    public class RegistrarDevolucionCommand : IRequest<Result>
    {
        public int PrestamoId { get; set; }
    }
}
