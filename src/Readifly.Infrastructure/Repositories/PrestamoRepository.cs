using Microsoft.EntityFrameworkCore;
using Readifly.Application.Common.Interfaces;
using Readifly.Domain.Entities;
using Readifly.Domain.Interfaces;

namespace Readifly.Infrastructure.Repositories
{
    public class PrestamoRepository : IRepositorioPrestamo
    {
        private readonly IApplicationDbContext _context;

        public PrestamoRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Prestamo> ObtenerPorIdAsync(int id)
        {
            return await _context.Prestamos
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Prestamo>> ObtenerPorUsuarioAsync(string usuarioId)
        {
            return await _context.Prestamos
                .Where(p => p.UsuarioId == usuarioId)
                .OrderByDescending(p => p.FechaPrestamo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> ObtenerActivosAsync()
        {
            return await _context.Prestamos
                .Where(p => !p.FechaDevolucionReal.HasValue)
                .OrderByDescending(p => p.FechaPrestamo)
                .ToListAsync();
        }

        public async Task<Prestamo> AgregarAsync(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }

        public async Task ActualizarAsync(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();
        }
    }
}
