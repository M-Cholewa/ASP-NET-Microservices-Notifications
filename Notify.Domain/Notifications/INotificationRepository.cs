using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Domain.Notifications
{
    public interface INotificationRepository
    {
        Task<Notification> GetByIdAsync(Guid id);
        Task<List<Notification>> GetByStatusAsync(NotificationStatus status);
        Task<List<Notification>> GetLastNotificationsAsync(int limit);

        void Add(Notification notification);
    }
}
