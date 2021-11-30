using Forum.Application.Commands.TopicViews;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Handler.Command
{
    public class TopicViewsCommandHandler : ValidateComandBase,
         IRequestHandler<AddTopicViewsCommand, bool>,
        IRequestHandler<UpdateTopicViewsCommand, bool>,
        IRequestHandler<DeleteTopicViewsCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITopicViewsRepository _topicViewsRepository;
        private readonly IUserRepository _userRepository;

        public TopicViewsCommandHandler(IMediatorHandler mediatorHandler,
            ITopicViewsRepository topicViewsRepository,
            ICommentRepository commentRepository,
            IUserRepository userRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _topicViewsRepository = topicViewsRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateTopicViewsCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var topicView = await _topicViewsRepository.GetById(command.Id);
           
            if (topicView == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("TopicViews", "TopicViews not found."));
                return false;
            }

            _topicViewsRepository.Update(topicView);

            return await _topicViewsRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AddTopicViewsCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var result = await _topicViewsRepository.GetByUserAndTopicId(command.TopicId, command.UserId);

            var topicView = new TopicViews(command.TopicId, command.UserId);

            if (!result.Any())
            {
                _topicViewsRepository.Add(topicView);
            }

            return await _topicViewsRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(DeleteTopicViewsCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var topicView = await _topicViewsRepository.GetById(command.Id);
           
            if (topicView == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("TopicViews", "TopicViews not found."));
                return false;
            }
            _topicViewsRepository.Delete(topicView);


            return await _topicViewsRepository.UnitOfWork.Commit();
        }
    }
}
