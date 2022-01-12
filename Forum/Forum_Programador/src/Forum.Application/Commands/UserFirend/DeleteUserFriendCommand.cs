using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.UserFirend
{
    public class DeleteUserFriendCommand : Command
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid UserToFollowId { get; private set; }

        public DeleteUserFriendCommand(Guid id, Guid userId, Guid usertoFollowId)
        {
            Id = id;
            UserId = userId;
            UserToFollowId = usertoFollowId;
            AggregateId = id;
        }


        public override bool IsValid()
        {
            ValidationResult = new DeleteUserFriendValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class DeleteUserFriendValidation : AbstractValidator<DeleteUserFriendCommand>
    {
        public DeleteUserFriendValidation()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid Id");
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("Invalid Id for User");
            RuleFor(x => x.UserToFollowId).NotEqual(Guid.Empty).WithMessage("Ibnvalid Id for User to follow");
        }

    }

}
