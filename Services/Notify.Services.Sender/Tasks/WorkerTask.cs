using MediatR;
using Notify.Application.Notifications.Commands;
using Notify.Contracts.Shared;

namespace Notify.Services.Sender.Tasks
{
    public class WorkerTask(
        NotificationDto notification,
        ISender mediator,
        ILogger<DispatcherTask> logger)
    {
        private readonly NotificationDto _notification = notification ?? throw new ArgumentNullException(nameof(notification));
        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        private readonly ILogger<DispatcherTask> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task ExecuteAsync()
        {
            _logger.LogInformation($"WorkerTask started for notification {_notification.Id}.");

            try
            {
                await _mediator.Send(new UpdateNotificationStatusCommand(_notification.Id, NotificationStatus.Sent));
                _logger.LogInformation($"Notification {_notification.Id} sent successfully to {_notification.NotificationType}.");
            }
            catch (Exception ex)
            {
                await _mediator.Send(new UpdateNotificationStatusCommand(_notification.Id, NotificationStatus.Failed));
                _logger.LogError(ex, $"Failed to send notification {_notification.Id} to {_notification.NotificationType}.");
            }
        }
    }


}
