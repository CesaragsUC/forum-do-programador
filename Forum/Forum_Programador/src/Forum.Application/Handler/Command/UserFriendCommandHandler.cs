using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Handler.Command
{
    public class UserFriendCommandHandler : ValidateComandBase
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
    }
}
