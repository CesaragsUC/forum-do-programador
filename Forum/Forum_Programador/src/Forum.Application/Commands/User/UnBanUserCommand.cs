using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.User
{
    public class UnBanUserCommand : Command
    {
        public Guid UserId { get; private set; }

        public UnBanUserCommand(Guid userid)
        {
            UserId = userid;
        }

        public override bool IsValid()
        {
            ValidationResult = new UnBanUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UnBanUserCommandValidation : AbstractValidator<UnBanUserCommand>
    {
        public UnBanUserCommandValidation()
        {
            RuleFor(u => u.UserId).NotEqual(Guid.Empty).WithMessage("Invalid user Id");
        }
    }
}
