using FluentValidation;
using Forum.Core.Messages;

namespace Forum.Application.Commands
{
    public class CreateSectionCommand : Command
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public CreateSectionCommand(string name, bool active)
        {
            Name = name;
            IsActive = active;
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
        }
    }
}
