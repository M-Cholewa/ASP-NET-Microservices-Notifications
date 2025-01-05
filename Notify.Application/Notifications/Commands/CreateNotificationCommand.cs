using Notify.Application.Configuration.Commands;
using Notify.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Application.Notifications.Commands
{
    public class CreateNotificationCommand(string message, string recipient, DateTime sendTime, NotificationType notificationType) : CommandBase<Guid>
    {
        public string Message { get; } = message ?? throw new ArgumentNullException(nameof(message));
        public string Recipient { get; } = recipient ?? throw new ArgumentNullException(nameof(recipient));
        public DateTime SendTime { get; } = sendTime;
        public NotificationType NotificationType { get; } = notificationType;
    }
}
