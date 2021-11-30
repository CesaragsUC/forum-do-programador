using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.PrivateMessages
{
    public class UpdatePrivateMessagesCommand : Command
    {

        public Guid Id { get; private set; }
        public Guid SenderId { get; private set; }
        public Guid RecipientId { get; private set; }
        public string Subject { get; private set; }
        public string Text { get; private set; }

        public UpdatePrivateMessagesCommand(Guid id, Guid senderId, Guid recipientId, string subject, string text)
        {
            Id = id;
            SenderId = senderId;
            RecipientId = recipientId;
            Subject = subject;
            Text = text;
            AggregateId = id;

        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePrivateMessagesValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdatePrivateMessagesValidator : AbstractValidator<UpdatePrivateMessagesCommand>
    {
        public UpdatePrivateMessagesValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid Id.");
            RuleFor(x => x.SenderId).NotEqual(Guid.Empty).WithMessage("Invalid RecipientId.");
            RuleFor(x => x.RecipientId).NotEqual(Guid.Empty).WithMessage("Invalid  SenderId.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("The text can't be empty.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("The text can't be empty.");
        }

    }
}
