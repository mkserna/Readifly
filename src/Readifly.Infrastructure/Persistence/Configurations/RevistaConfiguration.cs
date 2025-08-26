using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readifly.Domain.Entities;

namespace Readifly.Infrastructure.Persistence.Configurations
{
    public class RevistaConfiguration : IEntityTypeConfiguration<Revista>
    {
        public void Configure(EntityTypeBuilder<Revista> builder)
        {
            builder.Property(r => r.Editorial)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.Numero)
                .IsRequired();

            builder.Property(r => r.Volumen)
                .IsRequired();

            builder.Property(r => r.FechaPublicacion)
                .IsRequired();
        }
    }
}
