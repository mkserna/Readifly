using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Readifly.Application.Common.Interfaces;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;

namespace Readifly.Application.Features.Prestamos.Queries.ObtenerPrestamos
{
    public class ObtenerPrestamosQueryHandler : IRequestHandler<ObtenerPrestamosQuery, Result<IEnumerable<PrestamoDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ObtenerPrestamosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<PrestamoDto>>> Handle(ObtenerPrestamosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _context.Prestamos.AsQueryable();

                if (!string.IsNullOrEmpty(request.UsuarioId))
                {
                    query = query.Where(p => p.UsuarioId == request.UsuarioId);
                }

                if (request.SoloActivos.HasValue && request.SoloActivos.Value)
                {
                    query = query.Where(p => !p.FechaDevolucionReal.HasValue);
                }

                var prestamos = await query.ToListAsync(cancellationToken);
                var prestamosDto = _mapper.Map<IEnumerable<PrestamoDto>>(prestamos);

                return Result<IEnumerable<PrestamoDto>>.Success(prestamosDto);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<PrestamoDto>>.Failure($"Error al obtener préstamos: {ex.Message}");
            }
        }
    }
}

