using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.UserFirend
{
    public class DeleteUserCommand : Command
    {
        public Guid Id { get; private set; }
        public DeleteUserCommand(Guid userId)
        {
            Id = userId;
            AggregateId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteUserValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid UserId.");
        }

    }
}
