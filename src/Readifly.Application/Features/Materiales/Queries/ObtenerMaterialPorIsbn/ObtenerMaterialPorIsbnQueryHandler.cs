using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Readifly.Application.Common.Interfaces;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;

namespace Readifly.Application.Features.Materiales.Queries.ObtenerMaterialPorIsbn
{
    public class ObtenerMaterialPorIsbnQueryHandler : IRequestHandler<ObtenerMaterialPorIsbnQuery, Result<MaterialBibliograficoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ObtenerMaterialPorIsbnQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<MaterialBibliograficoDto>> Handle(ObtenerMaterialPorIsbnQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var material = await _context.MaterialesBibliograficos
                    .FirstOrDefaultAsync(m => m.ISBN == request.ISBN, cancellationToken);

                if (material == null)
                {
                    return Result<MaterialBibliograficoDto>.Failure("Material no encontrado");
                }

                var materialDto = _mapper.Map<MaterialBibliograficoDto>(material);
                return Result<MaterialBibliograficoDto>.Success(materialDto);
            }
            catch (Exception ex)
            {
                return Result<MaterialBibliograficoDto>.Failure($"Error al obtener material: {ex.Message}");
            }
        }
    }
}

