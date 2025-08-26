using MediatR;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;

namespace Readifly.Application.Features.Materiales.Queries.ObtenerMateriales
{
    public class ObtenerMaterialesQuery : IRequest<Result<IEnumerable<MaterialBibliograficoDto>>>
    {
        public bool? SoloDisponibles { get; set; }
    }
}
