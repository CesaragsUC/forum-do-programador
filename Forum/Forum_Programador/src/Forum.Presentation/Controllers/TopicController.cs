using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.Controllers
{
    public class TopicController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;

        public TopicController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
