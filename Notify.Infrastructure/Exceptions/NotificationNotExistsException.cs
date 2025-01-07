using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception that is thrown when notification does not exist
    /// </summary>
    public class NotificationNotExistsException(Guid notificationId) : Exception($"Notification with id {notificationId} does not exist")
    {
        public Guid NotificationId { get; } = notificationId;
    }
}
