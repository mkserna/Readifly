using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Readifly.Application.Common.Interfaces;
using Readifly.Domain.Interfaces;
using Readifly.Domain.Services;
using Readifly.Infrastructure.Persistence;
using Readifly.Infrastructure.Repositories;
using Readifly.Infrastructure.Services;

namespace Readifly.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // DbContext
            builder.RegisterType<ApplicationDbContext>()
                .As<IApplicationDbContext>()
                .InstancePerLifetimeScope();

            // Repositorios
            builder.RegisterType<MaterialBibliograficoRepository>()
                .As<IRepositorioMaterialBibliografico>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PrestamoRepository>()
                .As<IRepositorioPrestamo>()
                .InstancePerLifetimeScope();

            // Servicios
            builder.RegisterType<PrestamoService>()
                .As<IServicioPrestamo>()
                .InstancePerLifetimeScope();
        }
    }
}
