using Autofac;
using FluentValidation;
using MediatR;
using Readifly.Application.Common.Behaviors;
using Readifly.Application.Common.Mappings;
using System.Reflection;

namespace Readifly.Application
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // AutoMapper
            builder.RegisterAssemblyTypes(typeof(MappingProfile).Assembly)
                .Where(t => t.IsSubclassOf(typeof(AutoMapper.Profile)))
                .As<AutoMapper.Profile>();

            // MediatR
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(IRequestHandler<>))
                .AsImplementedInterfaces();

            // Validators
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            // Behaviors
            builder.RegisterGeneric(typeof(ValidationBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
        }
    }
}
