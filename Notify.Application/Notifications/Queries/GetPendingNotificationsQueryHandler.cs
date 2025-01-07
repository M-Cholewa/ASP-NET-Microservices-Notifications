using AutoMapper;
using Notify.Application.Configuration.Queries;
using Notify.Contracts.Shared;
using Notify.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Application.Notifications.Queries
{
    public class GetPendingNotificationsQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
    : IQueryHandler<GetPendingNotificationsQuery, List<NotificationDto>>
    {
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly INotificationRepository _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));

        public async Task<List<NotificationDto>> Handle(GetPendingNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notification = await _notificationRepository.GetByStatusAsync(Domain.Notifications.NotificationStatus.Pending);
            return _mapper.Map<List<NotificationDto>>(notification);
        }
    }
}
