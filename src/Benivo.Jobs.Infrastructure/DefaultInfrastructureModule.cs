using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Benivo.Jobs.Core.Interfaces;
using Benivo.Jobs.Core.ProjectAggregate;
using Benivo.Jobs.Infrastructure.Data;
using Benivo.Jobs.SharedKernel.Interfaces;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;

namespace Benivo.Jobs.Infrastructure
{
    /// <summary>
    /// Autofac module that defines DI registrations related to data persistence and related abstractions
    /// </summary>
    public class DefaultInfrastructureModule : Module
    {
        private readonly bool _isDevelopment = false;
        private readonly List<Assembly> _assemblies = new ();

        public DefaultInfrastructureModule(bool isDevelopment, Assembly? callingAssembly =  null)
        {
            _isDevelopment = isDevelopment;
            var coreAssembly = Assembly.GetAssembly(typeof(Project)); // TODO: Replace "Project" with any type from your Core project
            var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
            if (coreAssembly is not null) _assemblies.Add(coreAssembly);
            if (infrastructureAssembly is not null) _assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .As(typeof(IReadRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder.RegisterAssemblyTypes(_assemblies.ToArray())
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            builder.RegisterType<EmailSender>()
                .As<IEmailSender>()
                .InstancePerLifetimeScope();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
        }

    }
}
