using AutoMapper;
using Notify.Application.Configuration.Queries;
using Notify.Contracts.Shared;
using Notify.Domain.Notifications;

namespace Notify.Application.Notifications.Queries
{
    public class GetNotificationsQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
    : IQueryHandler<GetNotificationsQuery, List<NotificationDto>>
    {
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly INotificationRepository _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));

        public async Task<List<NotificationDto>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationRepository.GetLastNotificationsAsync(request.Limit);
            return _mapper.Map<List<NotificationDto>>(notifications);
        }
    }
}
