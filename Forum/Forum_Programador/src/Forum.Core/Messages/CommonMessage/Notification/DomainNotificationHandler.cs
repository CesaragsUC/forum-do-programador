using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Core.Messages.CommonMessage.Notification
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {

        public List<DomainNotification> _notifications;
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public virtual List<DomainNotification>GetNotification()
        {
            return _notifications;
        }

        public virtual bool HasNotificcation()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
