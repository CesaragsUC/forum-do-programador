using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.Area
{
    public class UpdateAreaCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public UpdateAreaCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateAreaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateAreaValidation : AbstractValidator<UpdateAreaCommand>
    {
        public UpdateAreaValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid ID");
        }
    }
}
