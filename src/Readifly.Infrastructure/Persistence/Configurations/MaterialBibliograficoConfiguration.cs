using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readifly.Domain.Entities;

namespace Readifly.Infrastructure.Persistence.Configurations
{
    public class MaterialBibliograficoConfiguration : IEntityTypeConfiguration<MaterialBibliografico>
    {
        public void Configure(EntityTypeBuilder<MaterialBibliografico> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.ISBN)
                .IsRequired()
                .HasMaxLength(17);

            builder.Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.EstaPrestado)
                .IsRequired();

            // Configuración para herencia TPH (Table Per Hierarchy)
            builder.HasDiscriminator<string>("TipoMaterial")
                .HasValue<Libro>("Libro")
                .HasValue<Revista>("Revista");

            // Las configuraciones específicas para Libro y Revista se manejan en configuraciones separadas

            // Índice único para ISBN
            builder.HasIndex(m => m.ISBN)
                .IsUnique();
        }
    }
}
