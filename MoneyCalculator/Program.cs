using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyCalculator.Domain;
using System.Threading.Tasks;

namespace MoneyCalculator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                    .AddEnvironmentVariables()
                                    .AddCommandLine(args)
                                    .Build();

            return Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Startup>();
                    services.AddScoped<IMoneyCalculator, MoneyCalculatorService>();
                    services.AddSingleton<IMoneyStorageService, MoneyStorageService>();
                    services.AddSingleton<ICurrencyStorageService, CurrencyStorageService>();

                }).ConfigureAppConfiguration(builder =>
                {
                    builder.Sources.Clear();
                    builder.AddConfiguration(configuration);
                });
        }
    }
}
