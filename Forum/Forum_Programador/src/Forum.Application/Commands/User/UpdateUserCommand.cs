using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.UserFirend
{
    public class UpdateUserCommand : Command
    {
        public Guid Id { get; set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }

        public string Avatar { get; private set; }

        public int UserTypeId { get; private set; }

        public UpdateUserCommand(Guid id,  string email, int usertypeId,string avatar,bool active)
        {
            Id = Id;
            AggregateId = id;
            Email = email;
            UserTypeId = usertypeId;
            IsActive = active;
            Avatar = avatar;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
    public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid IdentityId.");
            RuleFor(x => x.Email).NotEqual(string.Empty).WithMessage("Invalid Email.");
            RuleFor(x => x.UserTypeId).Must((x, type) => IsValidUserType(type).Equals(true)).WithMessage("Invalid User Type Id.");
        }

        private bool IsValidUserType(int type)
        {
            return type <= 0;
        }

    }
}
