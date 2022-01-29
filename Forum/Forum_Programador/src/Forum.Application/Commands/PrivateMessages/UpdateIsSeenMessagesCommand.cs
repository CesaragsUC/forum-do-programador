using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.PrivateMessages
{
    public class UpdateIsSeenMessagesCommand : Command
    {

        public Guid MessagetId { get; private set; }
        public Guid SenderId { get; private set; }
        public Guid LoggedUserId { get; private set; }

        public UpdateIsSeenMessagesCommand(Guid messageId, Guid senderId, Guid loggeduserid)
        {
            MessagetId = messageId;
            SenderId = senderId;
            LoggedUserId = loggeduserid;
            AggregateId = messageId;

        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePrivateMessagesValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdatePrivateMessagesValidator : AbstractValidator<UpdateIsSeenMessagesCommand>
    {
        public UpdatePrivateMessagesValidator()
        {
            RuleFor(x => x.MessagetId).NotEqual(Guid.Empty).WithMessage("Invalid Id.");
            RuleFor(x => x.SenderId).NotEqual(Guid.Empty).WithMessage("Invalid RecipientId.");
            RuleFor(x => x.LoggedUserId).NotEqual(Guid.Empty).WithMessage("Invalid  SenderId.");
        }

    }
}
