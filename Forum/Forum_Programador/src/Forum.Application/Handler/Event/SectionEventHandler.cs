using Forum.Application.Events;
using Forum.Core.Communication.Mediator;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Handler
{
    public class SectionHandlerEvent : 
        INotificationHandler<SectionCreatedEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;
        public SectionHandlerEvent(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public Task Handle(SectionCreatedEvent notification, CancellationToken cancellationToken)
        {
            //here i would implemet somethis to send a email informing that a new section has created.
            return Task.CompletedTask;
        }
    }
}
