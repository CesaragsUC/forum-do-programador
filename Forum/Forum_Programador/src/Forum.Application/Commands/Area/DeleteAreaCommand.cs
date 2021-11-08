using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.Area
{
    public class DeleteAreaCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public DeleteAreaCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new DeleteAreaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class DeleteAreaValidation : AbstractValidator<DeleteAreaCommand>
    {
        public DeleteAreaValidation()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid ID");
        }
    }
}
