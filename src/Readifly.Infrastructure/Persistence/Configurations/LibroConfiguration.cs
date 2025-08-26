using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readifly.Domain.Entities;

namespace Readifly.Infrastructure.Persistence.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.Property(l => l.Autor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.NumeroPaginas)
                .IsRequired();

            builder.Property(l => l.Editorial)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.AnioPublicacion)
                .IsRequired();
        }
    }
}
