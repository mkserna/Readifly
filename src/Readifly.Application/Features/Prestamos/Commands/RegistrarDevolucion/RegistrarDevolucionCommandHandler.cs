using MediatR;
using Microsoft.EntityFrameworkCore;
using Readifly.Application.Common.Interfaces;
using Readifly.Application.Common.Models;

namespace Readifly.Application.Features.Prestamos.Commands.RegistrarDevolucion
{
    public class RegistrarDevolucionCommandHandler : IRequestHandler<RegistrarDevolucionCommand, Result>
    {
        private readonly IApplicationDbContext _context;

        public RegistrarDevolucionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(RegistrarDevolucionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var prestamo = await _context.Prestamos
                    .FirstOrDefaultAsync(p => p.Id == request.PrestamoId, cancellationToken);

                if (prestamo == null)
                {
                    return Result.Failure("Préstamo no encontrado");
                }

                prestamo.RegistrarDevolucion();

                // Buscar el material y marcarlo como devuelto
                var material = await _context.MaterialesBibliograficos
                    .FirstOrDefaultAsync(m => m.ISBN == prestamo.ISBN, cancellationToken);

                if (material != null)
                {
                    material.MarcarComoDevuelto();
                    _context.MaterialesBibliograficos.Update(material);
                }

                _context.Prestamos.Update(prestamo);
                await _context.SaveChangesAsync(cancellationToken);

                return Result.Success();
            }
            catch (InvalidOperationException ex)
            {
                return Result.Failure(ex.Message);
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al registrar la devolución: {ex.Message}");
            }
        }
    }
}

