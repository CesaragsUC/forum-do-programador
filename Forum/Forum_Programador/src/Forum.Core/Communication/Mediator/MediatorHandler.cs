using Forum.Core.Messages;
using Forum.Core.Messages.CommonMessage.DomainEvents;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using System.Threading.Tasks;

namespace Forum.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishDomainEvent<T>(T notification) where T : DomainEvents
        {
            await _mediator.Publish(notification);
        }

        public async Task PublishEvent<T>(T _event) where T : Event
        {
            await _mediator.Publish(_event);
        }

        public async Task PublishDomainNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }

        public async Task<bool> SendCommand<T>(T command) where T : Command
        {
           return await _mediator.Send(command);
        }
    }
}
