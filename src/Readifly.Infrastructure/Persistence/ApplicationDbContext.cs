using Microsoft.EntityFrameworkCore;
using Readifly.Application.Common.Interfaces;
using Readifly.Domain.Entities;
using Readifly.Infrastructure.Persistence.Configurations;

namespace Readifly.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MaterialBibliografico> MaterialesBibliograficos => Set<MaterialBibliografico>();
        public DbSet<Prestamo> Prestamos => Set<Prestamo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MaterialBibliograficoConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());
            modelBuilder.ApplyConfiguration(new RevistaConfiguration());
            modelBuilder.ApplyConfiguration(new PrestamoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
