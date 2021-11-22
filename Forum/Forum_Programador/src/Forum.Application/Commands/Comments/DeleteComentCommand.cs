using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.Comments
{
    public class DeleteComentCommand : Command
    {
        public Guid Id { get; private set; }

        public Guid UserDeleteId { get; private set; }

        public DeleteComentCommand(Guid id,Guid userDeleteId)
        {
            Id = id;
            UserDeleteId = userDeleteId;
            AggregateId = id;

        }

    }
    public class DeleteComentValidator : AbstractValidator<DeleteComentCommand>
    {
        public DeleteComentValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid Id Commnet.");
        }

    }
}
