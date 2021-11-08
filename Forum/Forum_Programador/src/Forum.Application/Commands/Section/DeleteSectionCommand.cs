using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.Section
{
    public class DeleteSectionCommand : Command
    {
        public Guid Id { get; set; }

        public DeleteSectionCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteSectionValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class DeleteSectionValidation : AbstractValidator<DeleteSectionCommand>
    {
        public DeleteSectionValidation()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Id cant be empety");
        }
    }
}
