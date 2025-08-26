using MediatR;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;

namespace Readifly.Application.Features.Materiales.Queries.ObtenerMaterialPorIsbn
{
    public class ObtenerMaterialPorIsbnQuery : IRequest<Result<MaterialBibliograficoDto>>
    {
        public string ISBN { get; set; } = string.Empty;
    }
}
