using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IServiceCollection = BLL.Factory.IServiceCollection;

namespace BackgroundTasks
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private Timer? _timer;
        public IServiceProvider Services { get; }

        public TimedHostedService(ILogger<TimedHostedService> logger, IServiceProvider services)
        {
            _logger = logger;
            Services = services;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            var executionTime = DateTime.Today.AddHours(1);
            if (executionTime < DateTime.Now) executionTime = executionTime.AddDays(1);
            var dueTime = executionTime - DateTime.Now;
            _logger.LogInformation($"Due time for request is: {dueTime}");

            _timer = new Timer(DoWork!, 
                null, 
                dueTime, 
                TimeSpan.FromHours(24));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
            
            using (var scope = Services.CreateScope())
            {
                var bll = scope.ServiceProvider
                        .GetRequiredService<IServiceCollection>();

                var authors = await bll.Authors.GetAllAsync();
                foreach (var author in authors)
                {
                    _logger.LogInformation(author.Name);
                }
            }
            
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}