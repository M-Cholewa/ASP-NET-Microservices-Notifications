using Notify.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Notify.Domain.Notifications
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

    public class Notification : Entity, IAggregateRoot
    {
        public string Message { get; private set; }
        public string Recipient { get; private set; }
        public DateTime SendTimeUTC { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public NotificationStatus NotificationStatus { get; private set; }

        public static Notification Create(string message, string recipient, DateTime sendTimeUTC, NotificationType notificationType)
        {
            //CheckRule(new NotificationNameNotEmptyOnlyLettersRule(name));

            return new(message, recipient, sendTimeUTC, notificationType);
        }

        private Notification(string message, string recipient, DateTime sendTimeUTC, NotificationType notificationType) : base(Guid.NewGuid())
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
            SendTimeUTC = sendTimeUTC;
            NotificationType = notificationType;
            NotificationStatus = NotificationStatus.Pending;

            //AddDomainEvent(new NotificationCreatedEvent(Id));
        }

        public void UpdateStatus(NotificationStatus status)
        {
            NotificationStatus = status;
        }
    }
}
