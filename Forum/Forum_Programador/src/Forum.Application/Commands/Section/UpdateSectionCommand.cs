using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.Section
{
    public class UpdateSectionCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public bool IsActive  { get; private set; }
        public Guid AreaId { get; private set; }
        public UpdateSectionCommand(Guid id, string name,Guid areaId)
        {
            Id = id;
            Name = name;
            AreaId = areaId;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateSectionValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateSectionValidation : AbstractValidator<UpdateSectionCommand>
    {
        public UpdateSectionValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cant be empety");
            RuleFor(x => x.AreaId).NotEqual(Guid.Empty).WithMessage("AreaId can't be null");
        }
    }
}
