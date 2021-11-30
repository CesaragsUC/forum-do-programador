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
    public class UserInformationCommandHandler : ValidateComandBase
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserRepository _userRepository;
        private readonly IUserInformationRepository _userInformationRepository;

        public UserInformationCommandHandler(
            IMediatorHandler mediatorHandler,
            IUserRepository userRepository,
            IUserInformationRepository userInformationRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _userRepository = userRepository;
            _userInformationRepository = userInformationRepository;
        }


    }
}
