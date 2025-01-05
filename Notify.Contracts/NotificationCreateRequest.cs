using Notify.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Contracts
{
    public class NotificationCreateRequest(string message, string recipient, DateTime sendTimeUTC, NotificationType notificationType)
    {
        public string Message { get; } = message ?? throw new ArgumentNullException(nameof(message));
        public string Recipient { get; } = recipient ?? throw new ArgumentNullException(nameof(recipient));
        public DateTime SendTimeUTC { get; } = sendTimeUTC;
        public NotificationType NotificationType { get; } = notificationType;
    }
}
