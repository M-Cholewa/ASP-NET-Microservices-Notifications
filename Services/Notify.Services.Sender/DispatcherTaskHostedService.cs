using Notify.Services.Sender.Tasks;

namespace Notify.Services.Sender
{
    public class DispatcherTaskHostedService(IServiceProvider serviceProvider) : IHostedService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(ExecuteTask, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
            return Task.CompletedTask;
        }

        private void ExecuteTask(object state)
        {
            using var scope = _serviceProvider.CreateScope();
            var dispatcherTask = scope.ServiceProvider.GetRequiredService<DispatcherTask>();
            dispatcherTask.ExecuteAsync().Wait();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Dispose();
            return Task.CompletedTask;
        }
    }

}
