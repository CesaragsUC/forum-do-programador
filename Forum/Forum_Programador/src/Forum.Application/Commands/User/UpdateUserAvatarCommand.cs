using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.UserFirend
{
    public class UpdateUserAvatarCommand : Command
    {
        public Guid Id { get; set; }

        public string Avatar { get; private set; }


        public UpdateUserAvatarCommand(Guid id,string avatar)
        {
            Id = id;
            AggregateId = id;
            Avatar = avatar;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
    public class UpdateUserValidation : AbstractValidator<UpdateUserAvatarCommand>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid IdentityId.");
            RuleFor(x => x.Avatar).NotEqual(string.Empty).WithMessage("Invalid Avatar.");

        }

        private bool IsValidUserType(int type)
        {
            return type <= 0;
        }

    }
}
