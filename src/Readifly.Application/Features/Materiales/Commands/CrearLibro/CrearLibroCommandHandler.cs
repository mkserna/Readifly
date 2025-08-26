using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Readifly.Application.Common.Interfaces;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;
using Readifly.Domain.Entities;

namespace Readifly.Application.Features.Materiales.Commands.CrearLibro
{
    public class CrearLibroCommandHandler : IRequestHandler<CrearLibroCommand, Result<LibroDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CrearLibroCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<LibroDto>> Handle(CrearLibroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar si ya existe un material con el mismo ISBN
                var materialExistente = await _context.MaterialesBibliograficos
                    .FirstOrDefaultAsync(m => m.ISBN == request.ISBN, cancellationToken);

                if (materialExistente != null)
                {
                    return Result<LibroDto>.Failure("Ya existe un material con este ISBN");
                }

                var libro = new Libro(
                    request.ISBN,
                    request.Nombre,
                    request.Autor,
                    request.NumeroPaginas,
                    request.Editorial,
                    request.AnioPublicacion);

                _context.MaterialesBibliograficos.Add(libro);
                await _context.SaveChangesAsync(cancellationToken);

                var libroDto = _mapper.Map<LibroDto>(libro);
                return Result<LibroDto>.Success(libroDto);
            }
            catch (Exception ex)
            {
                return Result<LibroDto>.Failure($"Error al crear el libro: {ex.Message}");
            }
        }
    }
}
