using MediatR;
using Notify.Application.Notifications.Commands;
using Notify.Application.Notifications.Queries;
using Notify.Contracts.Shared;
using System.Threading.Tasks;

namespace Notify.Services.Sender.Tasks
{
    public class DispatcherTask(
        ISender mediator,
        ILogger<DispatcherTask> logger)
    {
        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        private readonly ILogger<DispatcherTask> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task ExecuteAsync()
        {
            _logger.LogInformation("DispatcherTask started.");

            var pendingNotifications = await _mediator.Send(new GetPendingNotificationsQuery());

            foreach (var notification in pendingNotifications)
            {
                try
                {
                    await _mediator.Send(new UpdateNotificationStatusCommand(notification.Id, NotificationStatus.Scheduled));

                    Hangfire.BackgroundJob.Schedule(
                        () => ExecuteWorkerTask(notification),
                        notification.SendTimeUTC - DateTime.UtcNow
                    );

                    _logger.LogInformation($"Scheduled task for notification {notification.Id} at {notification.SendTimeUTC}.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to schedule notification {notification.Id}.");
                    await _mediator.Send(new UpdateNotificationStatusCommand(notification.Id, NotificationStatus.Failed));
                }
            }

            _logger.LogInformation("DispatcherTask completed.");
        }

        [Hangfire.Queue("default")]
        public async Task ExecuteWorkerTask(NotificationDto notification)
        {
            var workerTask = new WorkerTask(notification, mediator, logger);
            await workerTask.ExecuteAsync();
        }

    }
}
