using Forum.Application.Commands.UserFirend;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Handler.Command
{
    public class UserCommandHandler : ValidateComandBase,
        IRequestHandler<AddUserCommand, bool>,
         IRequestHandler<UpdateUserCommand, bool>,
         IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserRepository _userRepository;


        public UserCommandHandler(
            IMediatorHandler mediatorHandler,
            IUserRepository userRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var user = new User(command.IdentityId, command.Name, command.Email, command.Avatar, command.UserTypeId);

            _userRepository.Add(user);

            return await _userRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var user = await _userRepository.GetById(command.Id);
            if (user == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(command.MessageType, "User not found!"));
                return false;
            }

            _userRepository.Delete(user);

            return await _userRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var user = await _userRepository.GetById(command.Id);
            if (user == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(command.MessageType, "User not found!"));
                return false;
            }

            user.Update(command.Email, command.UserTypeId, command.Avatar, command.IsActive);

            _userRepository.Update(user);

            return await _userRepository.UnitOfWork.Commit();
        }
    }
}
