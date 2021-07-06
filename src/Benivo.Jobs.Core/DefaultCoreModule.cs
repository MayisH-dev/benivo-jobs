using Autofac;
using Benivo.Jobs.Core.JobAggregate.Interfaces;
using Benivo.Jobs.Core.JobAggregate.Services;

namespace Benivo.Jobs.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JobCountService>()
                .As<IJobCountService>()
                .InstancePerLifetimeScope();
        }
    }
}
