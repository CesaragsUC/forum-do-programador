using Forum.Application.Commands.UserFirend;
using Forum.Application.Events.UserFriend;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Forum.Application.Commands.User;

namespace Forum.Application.Handler.Command
{
    public class UserFriendCommandHandler : ValidateComandBase,
        IRequestHandler<AddUserFriendCommand,bool>,
         IRequestHandler<DeleteUserFriendCommand, bool>

    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserRepository _userRepository;
        private readonly IUserFriendRepository _userFriendRepository;

        public UserFriendCommandHandler(
            IMediatorHandler mediatorHandler,
            IUserRepository userRepository,
            IUserFriendRepository userFriendRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _userRepository = userRepository;
            _userFriendRepository = userFriendRepository;
        }

        public async Task<bool> Handle(DeleteUserFriendCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var userFriend = await _userFriendRepository.GetById(command.Id);
            if (userFriend == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(command.MessageType, "Invalid data follow."));
                return false;
            }

            _userFriendRepository.Delete(userFriend);

            return await _userFriendRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AddUserFriendCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var userFriend = new UserFriends(command.UserId, command.UserToFollowId);

            var userFriendData = await _userFriendRepository.GetByUserAndFriendId(command.UserId, command.UserToFollowId);

            if (!userFriendData.Any())
            {
                _userFriendRepository.Add(userFriend);
            }
            else
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(command.MessageType, "Is Already friends"));
                return false;
            }


            //userFriend.AddEvent(new UserFriendEvent(userFriend.Id, command.UserId, command.UserToFollowId));

            return await _userFriendRepository.UnitOfWork.Commit();
        }


    }
}
