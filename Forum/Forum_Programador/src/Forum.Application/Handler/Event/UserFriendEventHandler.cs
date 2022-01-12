using Forum.Application.Events;
using Forum.Application.Events.UserFriend;
using Forum.Core.Communication.Mediator;
using Forum.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Handler
{
    public class UserFriendHandlerEvent : INotificationHandler<UserFriendEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserRepository _userRepository;
        private readonly IUserFriendRepository _userFriendRepository;

        public UserFriendHandlerEvent(
            IMediatorHandler mediatorHandler,
            IUserRepository userRepository,
            IUserFriendRepository userFriendRepository)
        {
            _mediatorHandler = mediatorHandler;
            _userRepository = userRepository;
            _userFriendRepository = userFriendRepository;
        }

        public async Task Handle(UserFriendEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
