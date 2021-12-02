using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.UserFirend
{
    public class AddUserCommand : Command
    {
        public Guid IdentityId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }

        public string Avatar { get; private set; }

        public int UserTypeId { get; private set; }

        public AddUserCommand(Guid identityId, string name, string email, int usertypeId)
        {
            IdentityId = identityId;
            Name = name;
            Email = email;
            UserTypeId = usertypeId;
            IsActive = true;
            Avatar = "https://i.imgur.com/v49GdGu.png";
        }

        public override bool IsValid()
        {
            ValidationResult = new AddUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddUserValidation : AbstractValidator<AddUserCommand>
    {
        public AddUserValidation()
        {
            RuleFor(x => x.IdentityId).NotEqual(Guid.Empty).WithMessage("Invalid IdentityId.");
            RuleFor(x => x.Name).NotEqual(string.Empty).WithMessage("Invalid Name.");
            RuleFor(x => x.Email).NotEqual(string.Empty).WithMessage("Invalid Email.");
            RuleFor(x => x.UserTypeId).NotNull().GreaterThan(0).WithMessage("Invalid User Type Id.");
        }

        private bool IsValidUserType(int type)
        {
            return type <= 0;
        }

    }

    public static class CustompasswordValidation
    {
        //is not used, is only a good stuff
        //usage: RuleFor(x => x.Password).Password();
        //Identity already do somethings like that, but in case  you have a custom register acount
        //then you would use this.
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 14)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage("Password is empty")
                .MinimumLength(minimumLength).WithMessage("Password max character is 14")
                .Matches("[A-Z]").WithMessage("Password need have one lowcase letter")
                .Matches("[a-z]").WithMessage("Password need have one upercase letter")
                .Matches("[0-9]").WithMessage("Password need have one number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password need have one special character");
            return options;
        }
    }


}
