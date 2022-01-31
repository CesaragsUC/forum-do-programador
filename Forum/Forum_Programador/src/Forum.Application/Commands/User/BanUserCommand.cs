using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.User
{
    public class BanUserCommand: Command
    {
        public Guid UserId { get; private set; }

        public BanUserCommand(Guid userid)
        {
            UserId = userid;
        }

        public override bool IsValid()
        {
            ValidationResult = new BanUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class BanUserCommandValidation : AbstractValidator<BanUserCommand>
    {
        public BanUserCommandValidation()
        {
            RuleFor(u => u.UserId).NotEqual(Guid.Empty).WithMessage("Invalid user Id");
        }
    }
}
