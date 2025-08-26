using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readifly.Domain.Entities;

namespace Readifly.Infrastructure.Persistence.Configurations
{
    public class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ISBN)
                .IsRequired()
                .HasMaxLength(17);

            builder.Property(p => p.UsuarioId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.FechaPrestamo)
                .IsRequired();

            builder.Property(p => p.FechaDevolucionProgramada)
                .IsRequired();

            builder.Property(p => p.FechaDevolucionReal)
                .IsRequired(false);

            // Índices para mejorar el rendimiento
            builder.HasIndex(p => p.UsuarioId);
            builder.HasIndex(p => p.ISBN);
            builder.HasIndex(p => p.FechaPrestamo);
        }
    }
}
