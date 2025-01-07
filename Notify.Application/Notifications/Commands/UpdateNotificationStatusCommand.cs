using Notify.Application.Configuration.Commands;
using Notify.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Application.Notifications.Commands
{
    public class UpdateNotificationStatusCommand(Guid notificationId, NotificationStatus notificationStatus) : CommandBase<Guid>
    {
        public Guid NotificationId { get; } = notificationId;
        public NotificationStatus NotificationStatus { get; } = notificationStatus;
    }
}
