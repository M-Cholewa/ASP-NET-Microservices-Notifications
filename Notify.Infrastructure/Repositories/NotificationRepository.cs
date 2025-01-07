using Ardalis.GuardClauses;
using MongoDB.Driver;
using Notify.Domain.Notifications;
using Notify.Infrastructure.Database;
using Notify.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Repositories
{
    internal class NotificationRepository(OrdersContext context, IEntityTracker entityTracker) : INotificationRepository
    {

        private readonly OrdersContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IEntityTracker _entityTracker = entityTracker ?? throw new ArgumentNullException(nameof(entityTracker));


        public void Add(Notification notification)
        {
            Guard.Against.Null(notification, nameof(notification), "Notification is required.");
            _entityTracker.Track(notification);
        }

        public async Task<Notification> GetByIdAsync(Guid id)
        {
            var notification = _entityTracker.Find<Notification>(id);
            if (notification != null) return notification;

            notification = await _context.Notifications.Find(c => c.Id == id).FirstOrDefaultAsync();

            if (notification == null)
            {
                throw new NotificationNotExistsException(id);
            }

            _entityTracker.Track(notification);

            return notification;
        }

        public async Task<List<Notification>> GetLastNotificationsAsync(int limit)
        {
            var list = await _context.Notifications.Find(c => true).Limit(limit).ToListAsync();

            foreach (var notification in list)
            {
                _entityTracker.Track(notification);
            }

            return list;
        }


        public async Task<List<Notification>> GetByStatusAsync(NotificationStatus status)
        {
            var list = await _context.Notifications.Find(c => c.NotificationStatus == status).ToListAsync();

            foreach (var notification in list)
            {
                _entityTracker.Track(notification);
            }

            return list;
        }


    }
}
