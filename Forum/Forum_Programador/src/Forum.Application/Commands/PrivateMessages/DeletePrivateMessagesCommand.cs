using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.PrivateMessages
{
    public class DeletePrivateMessagesCommand : Command
    {
        public Guid Id { get; private set; }
        public DeletePrivateMessagesCommand(Guid pmId)
        {
            Id = Id;
            AggregateId = Id;
        }
        public override bool IsValid()
        {
            ValidationResult = new DeletePrivateMessagesValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class DeletePrivateMessagesValidator : AbstractValidator<DeletePrivateMessagesCommand>
    {
        public DeletePrivateMessagesValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid Id.");
        }

    }
}

