using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands
{
    public class CreateSectionCommand : Command
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public Guid AreaId { get; private set; }
        public CreateSectionCommand(string name, bool active,Guid areaId)
        {
            Name = name;
            IsActive = active;
            AreaId = areaId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateSectionValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }


    public class CreateSectionValidation : AbstractValidator<CreateSectionCommand>
    {
        public CreateSectionValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Section name cant be  empery");
            RuleFor(x => x.AreaId).NotEqual(Guid.Empty).WithMessage("AreaId can't be null");
        }
    }
}
