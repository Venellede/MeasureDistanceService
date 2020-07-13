using CTeleport.Distance.Api.xIntegrationTests.Clients;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CTeleport.Distance.Api.xIntegrationTests.Fixtures
{
    public class MeasureDistanceFixture<TStartup> : IAsyncLifetime where TStartup : class
    {
        public ServiceProvider ServiceProvider { get; set; }
        protected TestServer LocalTestServer;

        public async Task InitializeAsync()
        {
            var services = new ServiceCollection();
            var configurationBuilder = new ConfigurationBuilder();
            services.AddSingleton<IConfiguration>(configurationBuilder.AddJsonFile("appsettings.json").Build());

            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json");
                    config.AddEnvironmentVariables();
                });
            builder.ConfigureLogging((context, loggingBuilder) =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
            builder.UseStartup<TStartup>();

            LocalTestServer = new TestServer(builder);

            var client = LocalTestServer.CreateClient();
            services.AddScoped(p => RestService.For<IMeasureDistanceClient>(client));
            services.AddScoped(p => RestService.For<IMeasureDistanceResponse>(client));

            ServiceProvider = services.BuildServiceProvider(false);
            await Task.CompletedTask;
        }

        public async Task DisposeAsync()
        {
            ServiceProvider?.Dispose();
            await Task.CompletedTask;
        }

    }
}
