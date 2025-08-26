using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Readifly.Application.Common.Interfaces;
using Readifly.Domain.Interfaces;
using Readifly.Domain.Services;
using Readifly.Infrastructure.Persistence;
using Readifly.Infrastructure.Repositories;
using Readifly.Infrastructure.Services;

namespace Readifly.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de Entity Framework para MySQL
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            // Repositorios
            services.AddScoped<IRepositorioMaterialBibliografico, MaterialBibliograficoRepository>();
            services.AddScoped<IRepositorioPrestamo, PrestamoRepository>();

            // Servicios
            services.AddScoped<IServicioPrestamo, PrestamoService>();

            return services;
        }
    }
}
