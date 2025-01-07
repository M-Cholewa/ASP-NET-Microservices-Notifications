using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Contracts.Shared
{
    public enum NotificationType
    {
        Email,
        Push
    }

    public enum NotificationStatus
    {
        Pending,
        Scheduled,
        Sent,
        Failed
    }

    public class NotificationDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Recipient { get; set; }
        public DateTime SendTimeUTC { get; set; }
        public NotificationType NotificationType { get; set; }
        public NotificationStatus NotificationStatus { get; set; }

        public NotificationDto() { }

        public NotificationDto(Guid id, string message, string recipient, DateTime sendTimeUTC, NotificationType notificationType, NotificationStatus notificationStatus)
        {
            Id = id;
            Message = message;
            Recipient = recipient;
            SendTimeUTC = sendTimeUTC;
            NotificationType = notificationType;
            NotificationStatus = notificationStatus;
        }
    }
}
