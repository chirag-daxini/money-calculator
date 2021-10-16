using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyCalculator
{
    public class Startup : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Program Started");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Program ended");
        }
    }
}
