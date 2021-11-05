using Forum.Application.Commands;
using Forum.Application.Events;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Handler
{
    public class CreateTopicCommandHandler : ValidateComandBase,
        IRequestHandler<CreateTopicCommand, bool>
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITopicRepository _topicRepository;

        public CreateTopicCommandHandler(IMediatorHandler mediatorHandler,
            ITopicRepository topicRepository):base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _topicRepository = topicRepository;
        }

        public async Task<bool> Handle(CreateTopicCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var topic = new Topic(command.Name,command.UserId);

            _topicRepository.Add(topic);


            topic.AddEvent(new TopicCreatedEvent(topic.Id,command.UserId,command.Name));
            return  await _topicRepository.UnitOfWork.Commit();
        }


    }
}
