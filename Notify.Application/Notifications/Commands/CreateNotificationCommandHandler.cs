using AutoMapper;
using MediatR;
using Notify.Application.Configuration.Commands;
using Notify.Domain.Notifications;
using Notify.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Application.Notifications.Commands
{
    public class CreateNotificationCommandHandler(
    INotificationRepository notificationRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : ICommandHandler<CreateNotificationCommand, Guid>
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notificationType = _mapper.Map<NotificationType>(request.NotificationType);

            var notification = Notification.Create(request.Message,
                request.Recipient,
                request.SendTime,
                notificationType);

            _notificationRepository.Add(notification);

            await _unitOfWork.CommitAsync(cancellationToken);

            return notification.Id;
        }
    }
}
