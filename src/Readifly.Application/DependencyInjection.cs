using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Readifly.Application.Common.Behaviors;
using Readifly.Application.Common.Mappings;
using System.Reflection;

namespace Readifly.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
