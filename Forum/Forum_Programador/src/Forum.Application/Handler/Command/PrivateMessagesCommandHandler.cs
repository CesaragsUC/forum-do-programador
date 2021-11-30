using Forum.Application.Commands.PrivateMessages;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Handler.Command
{
    public class PrivateMessagesCommandHandler : ValidateComandBase,
                 IRequestHandler<AddPrivateMessagesCommand, bool>,
                 IRequestHandler<UpdatePrivateMessagesCommand, bool>,
                 IRequestHandler<DeletePrivateMessagesCommand, bool>
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

            throw new System.NotImplementedException();
        }

        public async Task<bool> Handle(UpdatePrivateMessagesCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            throw new System.NotImplementedException();
        }
    }
}
