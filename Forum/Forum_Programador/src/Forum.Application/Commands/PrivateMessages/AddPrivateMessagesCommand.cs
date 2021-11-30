using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.PrivateMessages
{
    public class AddPrivateMessagesCommand : Command
    {
        public Guid SenderId { get; private set; }
        public Guid RecipientId { get; private set; }
        public string Subject { get; private set; }
        public string Text { get; private set; }

        public AddPrivateMessagesCommand(Guid senderId,Guid recipientId, string subject, string text)
        {
            SenderId = senderId;
            RecipientId = recipientId;
            Subject = subject;
            Text = text;

        }

        public override bool IsValid()
        {
            ValidationResult = new AddPrivateMessagesValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddPrivateMessagesValidator : AbstractValidator<AddPrivateMessagesCommand>
    {
        public AddPrivateMessagesValidator()
        {
            RuleFor(x => x.SenderId).NotEqual(Guid.Empty).WithMessage("Invalid RecipientId.");
            RuleFor(x => x.RecipientId).NotEqual(Guid.Empty).WithMessage("Invalid  SenderId.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("The text can't be empty.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("The text can't be empty.");
        }

    }
}
