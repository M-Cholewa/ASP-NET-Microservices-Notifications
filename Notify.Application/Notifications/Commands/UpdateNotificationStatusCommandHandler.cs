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
    public class UpdateNotificationStatusCommandHandler(
    INotificationRepository notificationRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : ICommandHandler<UpdateNotificationStatusCommand, Guid>
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<Guid> Handle(UpdateNotificationStatusCommand request, CancellationToken cancellationToken)
        {
            var notification = await _notificationRepository.GetByIdAsync(request.NotificationId);

            var notificationStatus = _mapper.Map<Domain.Notifications.NotificationStatus>(request.NotificationStatus);

            notification.UpdateStatus(notificationStatus);
            await _unitOfWork.CommitAsync(cancellationToken);
            return notification.Id;
        }
    }
}
