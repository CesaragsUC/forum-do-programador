using Forum.Application.Commands.UserFirend;
using Forum.Application.Commands.UserInfo;
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
         IRequestHandler<DeleteUserCommand, bool>,
        IRequestHandler<UpdateUserInformationCommand, bool>,
        IRequestHandler<AddUserInformationCommand, bool>

    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserRepository _userRepository;
        private readonly IUserInformationRepository _userInformationRepository;


        public UserCommandHandler(
            IMediatorHandler mediatorHandler,
            IUserRepository userRepository,
            IUserInformationRepository userInformationRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _userRepository = userRepository;
            _userInformationRepository = userInformationRepository;
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

            user.Update(command.UserTypeId, command.IsActive);

            _userRepository.Update(user);

            return await _userRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(UpdateUserInformationCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var user = await _userRepository.GetById(command.UserId);

            //check if user information already exist
            var userInfo = await _userInformationRepository.GetByUserId(command.UserId);

            if (user == null || userInfo == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(command.MessageType, "User not found!"));
                return false;
            }

            if (!string.IsNullOrEmpty(command.Email))
            {
                if(user.Email != command.Email)
                {
                    user.UpdateEmail(command.Email);
                    _userRepository.Update(user);
                }

            }

            userInfo.UpdateInformation(userInfo.Id,command.UserId, command.WebSite, command.GitHub,
                command.Twitter, command.Instagran, command.FaceBook, command.FullName,
                command.Occupation, command.Adress);


            _userRepository.UpdateUserInformation(userInfo);


            return await _userRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AddUserInformationCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var user = await _userRepository.GetById(command.UserId);

            if (user == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(command.MessageType, "User not found!"));
                return false;
            }

            if (!string.IsNullOrEmpty(command.Email))
            {
                user.UpdateEmail(command.Email);
                _userRepository.Update(user);
            }
                

            var userInfo = new UserInformation(user.Id, command.WebSite, command.GitHub,
                command.Twitter, command.Instagran, command.FaceBook, command.FullName,
                command.Occupation, command.Adress);


            _userRepository.AddUserInformation(userInfo);

            return await _userRepository.UnitOfWork.Commit();
        }
    }
}
