using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Phani.HostedService
{
    public class PhaniHostedService: IHostedService
    {
        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Timer executes for every 5 seconds
            _timer = new Timer(WriteToConsole, "Started", 0, 5000);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        void WriteToConsole(object state)
        {
            Console.WriteLine($"{ DateTime.Now.ToString() } - Phani Hosted Service {state}");
        }


    }
}
