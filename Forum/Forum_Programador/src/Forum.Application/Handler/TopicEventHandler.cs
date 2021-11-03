using Forum.Application.Events;
using Forum.Core.Communication.Mediator;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Handler
{
    public class TopicHandlerEvent : INotificationHandler<TopicCreatedEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;
        public TopicHandlerEvent(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public Task Handle(TopicCreatedEvent notification, CancellationToken cancellationToken)
        {
            //aqui poderia implementar o envio de email avisando que foi criado um novo topico
            return Task.CompletedTask;
        }
    }
}
