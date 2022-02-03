using System;
using Forum.Application.Commands;
using Forum.Application.Commands.Comments;
using Forum.Application.Commands.Topic;
using Forum.Application.Events;
using Forum.Application.Events.Topic;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Handler
{
    public class TopicCommandHandler : ValidateComandBase,
        IRequestHandler<CreateTopicCommand, bool>,
        IRequestHandler<UpdateTopicCommand, bool>,
        IRequestHandler<DeleteTopicCommand, bool>
    // IRequestHandler<ReplyTopicCommand, bool>


    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITopicRepository _topicRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public TopicCommandHandler(IMediatorHandler mediatorHandler,
            ITopicRepository topicRepository,
            ICommentRepository commentRepository,
            IUserRepository userRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _topicRepository = topicRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CreateTopicCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var topic = new Topic(command.Title, command.UserId, command.SectionId);

            var comment = new Comments(command.Text, command.UserId, topic.Id, 1);
            topic.AddCommnet(comment);

            _topicRepository.Add(topic);
           // _topicRepository.AddComment(comment);

            topic.AddEvent(new TopicCreatedEvent(topic.Id, command.UserId, command.Title));
            return await _topicRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(UpdateTopicCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var topic = await _topicRepository.GetById(command.Id);
            if (topic == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("topic", "Topic not found"));
                return false;
            }

            topic.UpdateTitle(command.Title);
            topic.UpdateSection(command.SectionId);

            return await _topicRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(DeleteTopicCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var topic = await _topicRepository.GetById(command.Id);

            if (topic == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("topic", "topic not found."));
                return false;
            }

            //need delete all coments from this topic before.
            var comments = await _commentRepository.ByTopicId(topic.Id);
            foreach (var comment in comments)
            {
                try
                {
                    _topicRepository.DeleteComments(comment);
                }
                catch (Exception e)
                {
                   
                    throw e;
                }

            }

            _topicRepository.Delete(topic);

            return await _topicRepository.UnitOfWork.Commit();
        }

        //public async Task<bool> Handle(ReplyTopicCommand command, CancellationToken cancellationToken)
        //{
        //    if (!ValidateCommand(command)) return false;

        //    //first check if the topic exist
        //    var topic = await _topicRepository.GetById(command.Id);

        //    if (topic == null)
        //    {
        //        await _mediatorHandler.PublishDomainNotification(new DomainNotification("topic", "topic not found."));
        //        return false;
        //    }

        //    //get reply user data
        //    //todo add Indentity tables
        //    //var user = await _userRepository.GetById(command.UserId);

        //    //first check all coments from this topic
        //    var coments = await _commentRepository.GetByTopicId(topic.Id);

        //    //get the last commentId to increase
        //    int comentId = coments.Max(x => x.CommentId);

        //    //last comentId + 1
        //    var comment = new Comments(command.Text, command.UserId, topic.Id, comentId++);


        //    _commentRepository.Add(comment);


        //    topic.AddEvent(new TopicReplyEvent(topic.Id, command.UserId, "Cesar"));

        //    return await _commentRepository.UnitOfWork.Commit();
        //}

    }
}
