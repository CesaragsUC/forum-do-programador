using Forum.Application.Commands.PrivateMessages;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Entities;

namespace Forum.Application.Handler.Command
{
    public class PrivateMessagesCommandHandler : ValidateComandBase,
                 IRequestHandler<AddPrivateMessagesCommand, bool>,
                 IRequestHandler<UpdatePrivateMessagesCommand, bool>,
                 IRequestHandler<DeletePrivateMessagesCommand, bool>,
                 IRequestHandler<AddMessagesCommentCommand,bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPrivateMessageRepository _privateMessageRepository;
        private readonly IUserRepository _userRepository;

        public PrivateMessagesCommandHandler(IMediatorHandler mediatorHandler,
            IPrivateMessageRepository privateMessageRepository,
            ICommentRepository commentRepository,
            IUserRepository userRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _privateMessageRepository = privateMessageRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeletePrivateMessagesCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            throw new System.NotImplementedException();
        }

        public async Task<bool> Handle(AddPrivateMessagesCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;


            var message = new PrivateMessages(command.SenderId, command.RecipientId, command.Subject);

            var messageComment = new MessageComment(command.SenderId, message.Id, command.Text);

            _privateMessageRepository.Add(message);
            _privateMessageRepository.AddMessageComment(messageComment);

            return await _privateMessageRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(UpdatePrivateMessagesCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            throw new System.NotImplementedException();
        }

        public async Task<bool> Handle(AddMessagesCommentCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var messageComment = new MessageComment(command.UserId, command.PrivateMessageId, command.Text);

            var pm = await _privateMessageRepository.GetById(command.PrivateMessageId);
            if (pm == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("AddMessagesCommentCommand", "Message not found."));
                return false;
            }

            pm.SetIsReplied();

            _privateMessageRepository.Update(pm);
            _privateMessageRepository.AddMessageComment(messageComment);

            return await _privateMessageRepository.UnitOfWork.Commit();
        }
    }
}
