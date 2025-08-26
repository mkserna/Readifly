using Microsoft.EntityFrameworkCore;
using Readifly.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Readifly.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<MaterialBibliografico> MaterialesBibliograficos { get; }
        DbSet<Prestamo> Prestamos { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
