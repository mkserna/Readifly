using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Readifly.Application.Common.Interfaces;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;
using Readifly.Domain.Entities;

namespace Readifly.Application.Features.Materiales.Commands.CrearRevista
{
    public class CrearRevistaCommandHandler : IRequestHandler<CrearRevistaCommand, Result<RevistaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CrearRevistaCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<RevistaDto>> Handle(CrearRevistaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar si ya existe un material con el mismo ISBN
                var materialExistente = await _context.MaterialesBibliograficos
                    .FirstOrDefaultAsync(m => m.ISBN == request.ISBN, cancellationToken);

                if (materialExistente != null)
                {
                    return Result<RevistaDto>.Failure("Ya existe un material con este ISBN");
                }

                var revista = new Revista(
                    request.ISBN,
                    request.Nombre,
                    request.Editorial,
                    request.Numero,
                    request.Volumen,
                    request.FechaPublicacion);

                _context.MaterialesBibliograficos.Add(revista);
                await _context.SaveChangesAsync(cancellationToken);

                var revistaDto = _mapper.Map<RevistaDto>(revista);
                return Result<RevistaDto>.Success(revistaDto);
            }
            catch (Exception ex)
            {
                return Result<RevistaDto>.Failure($"Error al crear la revista: {ex.Message}");
            }
        }
    }
}

