using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.UserFirend
{
    public class AddUserFriendCommand : Command
    {
        public Guid UserId { get; private set; }
        public Guid UserToFollowId { get; private set; }

        public AddUserFriendCommand(Guid userId, Guid usertoFollowId)
        {
            UserId = userId;
            UserToFollowId = usertoFollowId;
        }


        public override bool IsValid()
        {
            ValidationResult = new AdduserFriendValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdduserFriendValidation : AbstractValidator<AddUserFriendCommand>
    {
        public AdduserFriendValidation()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("Ibnvalid Id for User");
            RuleFor(x => x.UserToFollowId).NotEqual(Guid.Empty).WithMessage("Ibnvalid Id for User to follow");
        }

    }
}
