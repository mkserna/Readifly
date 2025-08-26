using Microsoft.EntityFrameworkCore;
using Readifly.Application.Common.Interfaces;
using Readifly.Domain.Entities;
using Readifly.Domain.Interfaces;

namespace Readifly.Infrastructure.Repositories
{
    public class MaterialBibliograficoRepository : IRepositorioMaterialBibliografico
    {
        private readonly IApplicationDbContext _context;

        public MaterialBibliograficoRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MaterialBibliografico> ObtenerPorIsbnAsync(string isbn)
        {
            return await _context.MaterialesBibliograficos
                .FirstOrDefaultAsync(m => m.ISBN == isbn);
        }

        public async Task<IEnumerable<MaterialBibliografico>> ObtenerTodosAsync()
        {
            return await _context.MaterialesBibliograficos
                .ToListAsync();
        }

        public async Task<IEnumerable<MaterialBibliografico>> ObtenerDisponiblesAsync()
        {
            return await _context.MaterialesBibliograficos
                .Where(m => !m.EstaPrestado)
                .ToListAsync();
        }

        public async Task<MaterialBibliografico> AgregarAsync(MaterialBibliografico material)
        {
            _context.MaterialesBibliograficos.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }

        public async Task ActualizarAsync(MaterialBibliografico material)
        {
            _context.MaterialesBibliograficos.Update(material);
            await _context.SaveChangesAsync();
        }
    }
}
