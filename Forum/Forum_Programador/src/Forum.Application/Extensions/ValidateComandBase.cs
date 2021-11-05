using Forum.Core.Communication.Mediator;
using Forum.Core.Messages;
using Forum.Core.Messages.CommonMessage.Notification;

namespace Forum.Application.Extensions
{
    public abstract class ValidateComandBase
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ValidateComandBase(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }
        public bool ValidateCommand(Command command)
        {
            if (command.IsValid()) return true;

            foreach (var error in command.ValidationResult.Errors)
            {
                _mediatorHandler.PublishDomainNotification(
                    new DomainNotification(command.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
