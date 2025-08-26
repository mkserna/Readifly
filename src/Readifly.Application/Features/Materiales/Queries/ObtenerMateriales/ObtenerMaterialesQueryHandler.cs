using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Readifly.Application.Common.Interfaces;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;

namespace Readifly.Application.Features.Materiales.Queries.ObtenerMateriales
{
    public class ObtenerMaterialesQueryHandler : IRequestHandler<ObtenerMaterialesQuery, Result<IEnumerable<MaterialBibliograficoDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ObtenerMaterialesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<MaterialBibliograficoDto>>> Handle(ObtenerMaterialesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _context.MaterialesBibliograficos.AsQueryable();

                if (request.SoloDisponibles.HasValue && request.SoloDisponibles.Value)
                {
                    query = query.Where(m => !m.EstaPrestado);
                }

                var materiales = await query.ToListAsync(cancellationToken);
                var materialesDto = _mapper.Map<IEnumerable<MaterialBibliograficoDto>>(materiales);

                return Result<IEnumerable<MaterialBibliograficoDto>>.Success(materialesDto);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<MaterialBibliograficoDto>>.Failure($"Error al obtener materiales: {ex.Message}");
            }
        }
    }
}

