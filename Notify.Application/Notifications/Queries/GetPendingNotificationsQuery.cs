using Notify.Application.Configuration.Queries;
using Notify.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Application.Notifications.Queries
{
    public class GetPendingNotificationsQuery : IQuery<List<NotificationDto>>
    {
    }
}
