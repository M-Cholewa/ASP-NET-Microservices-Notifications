using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notify.Application.Notifications.Commands;
using Notify.Application.Notifications.Queries;
using Notify.Application.Orders.CustomerOrder.Commands;
using Notify.Contracts;
using Notify.Contracts.Shared;
using System.Net;

namespace Notify.API.Controllers
{
    [ApiController]
    [Route("api/v1/notifications")]
    public class NotificationController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = Guard.Against.Null(sender, nameof(sender));

        /// <summary>
        /// Sends notification.
        /// </summary>
        /// <param name="request">The request containing details.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A newly created notification ID.</returns>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadGateway)]
        public async Task<IActionResult> AddNotification(
            [FromBody] NotificationCreateRequest request,
            CancellationToken cancellationToken = default)
        {
            var notificationId = await _sender.Send(new CreateNotificationCommand(request.Message,
                request.Recipient,
                request.SendTimeUTC,
                request.NotificationType), cancellationToken);

            return Created($"api/v1/notifications", notificationId);
        }


        /// <summary>
        /// Gets last 15 notifications.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>List of notifications.</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<NotificationDto>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadGateway)]
        public async Task<IActionResult> GetNotifications(CancellationToken cancellationToken = default)
        {
            var notifications = await _sender.Send(new GetNotificationsQuery(), cancellationToken);

            return Ok(notifications);
        }
    }
}
