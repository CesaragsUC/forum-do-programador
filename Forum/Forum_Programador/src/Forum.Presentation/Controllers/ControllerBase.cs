using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Presentation.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        private readonly IMediatorHandler _mediatorHandler;

        protected Guid UserId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        public ControllerBase(
            INotificationHandler<DomainNotification> notification,
            IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notification;
            _mediatorHandler = mediatorHandler;
        }

        protected bool IsvalidOpperation()
        {
            return !_notifications.HasNotificcation();
        }

        protected IEnumerable<string> GetMessageErros()
        {
            return _notifications.GetNotification().Select(x => x.Value).ToList();
        }

        protected void NotifyError(string cod, string msg)
        {
            _mediatorHandler.PublishDomainNotification(new DomainNotification(cod, msg));
        }
    }

}
