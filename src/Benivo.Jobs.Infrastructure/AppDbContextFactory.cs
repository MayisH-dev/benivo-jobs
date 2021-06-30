using Autofac;
using Autofac.Extensions.DependencyInjection;
using Benivo.Jobs.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Benivo.Jobs.Infrastructure
{
    /// <summary>
    /// Defines dbContext creation options at design time (e.g. when applying migrations)
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args) =>
            new HostBuilder()
                // Add more configuration providers (cli args, env variables, key-per-file)
                // If production systems intend to migrate automatically
                .ConfigureAppConfiguration(a => a.AddUserSecrets<AppDbContextFactory>())
                .ConfigureServices(
                    (hostBuilder, services) =>
                        services.AddDbContext<AppDbContext>(
                            options => options.UseSqlServer(
                                hostBuilder.Configuration.GetConnectionString("DefaultConnection"))))
                .UseServiceProviderFactory(
                    new AutofacServiceProviderFactory(opt =>
                        opt.RegisterModule(
                            new DefaultInfrastructureModule(isDevelopment: true))))
                .Build()
                .Services
                .GetRequiredService<AppDbContext>();
    }
}
