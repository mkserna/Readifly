using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Readifly.Application.Common.Interfaces;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;
using Readifly.Domain.Entities;

namespace Readifly.Application.Features.Prestamos.Commands.RealizarPrestamo
{
    public class RealizarPrestamoCommandHandler : IRequestHandler<RealizarPrestamoCommand, Result<PrestamoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RealizarPrestamoCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PrestamoDto>> Handle(RealizarPrestamoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var material = await _context.MaterialesBibliograficos
                    .FirstOrDefaultAsync(m => m.ISBN == request.ISBN, cancellationToken);

                if (material == null)
                {
                    return Result<PrestamoDto>.Failure("Material no encontrado");
                }

                var prestamo = Prestamo.CrearPrestamo(material, request.UsuarioId);

                _context.Prestamos.Add(prestamo);
                _context.MaterialesBibliograficos.Update(material);
                await _context.SaveChangesAsync(cancellationToken);

                var prestamoDto = _mapper.Map<PrestamoDto>(prestamo);
                return Result<PrestamoDto>.Success(prestamoDto);
            }
            catch (InvalidOperationException ex)
            {
                return Result<PrestamoDto>.Failure(ex.Message);
            }
            catch (Exception ex)
            {
                return Result<PrestamoDto>.Failure($"Error al realizar el préstamo: {ex.Message}");
            }
        }
    }
}

