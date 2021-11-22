using Forum.Application.Commands.Comments;
using Forum.Application.Commands.Topic;
using Forum.Application.Events.Comments;
using Forum.Application.Events.Topic;
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

    public class CommentCommandHandler : ValidateComandBase,
    IRequestHandler<AddComentCommand, bool>,
        IRequestHandler<EditComentCommand, bool>,
        IRequestHandler<DeleteComentCommand, bool>


    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITopicRepository _topicRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public CommentCommandHandler(IMediatorHandler mediatorHandler,
            ITopicRepository topicRepository,
            ICommentRepository commentRepository,
            IUserRepository userRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _topicRepository = topicRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(AddComentCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            //first check if the topic exist
            var topic = await _topicRepository.GetById(command.TopicId);
            int comentId = 0;

            if (topic == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("topic", "topic not found."));
                return false;
            }

            //get reply user data
            //todo add Indentity tables
            var user = await _userRepository.GetById(command.UserId);

            //first check all coments from this topic
            var coments = await _commentRepository.GetByTopicId(topic.Id);

            //there unles 1 coment in topic? then increase comentId
            if (coments.Any())
            {
                //get the last commentId to increase
                comentId = coments.Max(x => x.CommentId);
                comentId++;
            }
            else
            {
                // no have any coment in topic, then mean that is a new topic, comentId = 1 by default
                comentId = 1;
            }

            //last comentId + 1
            var comment = new Comments(command.Text, command.UserId, topic.Id, comentId);

            _commentRepository.Add(comment);

            topic.AddEvent(new TopicReplyEvent(topic.Id, command.UserId, user.Name));

            return await _commentRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(EditComentCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            //coments exist?
            var coment = await _commentRepository.GetById(command.Id);
            if (coment == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("coment", "coment not found."));
                return false;
            }

            coment.UpdateText(command.Text);

            _commentRepository.Update(coment);

            return await _commentRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(DeleteComentCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;


            //coments exist?
            var coment = await _commentRepository.GetById(command.Id);
            if (coment == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("coment", "coment not found."));
                return false;
            }

            _commentRepository.Delete(coment);

            coment.AddEvent(new ComentDeletedEvent(coment.Id, command.UserDeleteId, coment.TopicId));

            return await _commentRepository.UnitOfWork.Commit();
        }
    }
}
