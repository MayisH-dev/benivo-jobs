using Autofac;
using Benivo.Jobs.Core.Interfaces;
using Benivo.Jobs.Core.Services;

namespace Benivo.Jobs.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>()
                .InstancePerLifetimeScope();
        }
    }
}
