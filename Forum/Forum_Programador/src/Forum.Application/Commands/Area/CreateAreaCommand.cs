using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.Area
{
    public class CreateAreaCommand : Command
    {

        public string Name { get; private set; }

        public CreateAreaCommand(string name)
        {
            Name = name;
        }
        public override bool IsValid()
        {
            ValidationResult = new CreateAreaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CreateAreaValidation : AbstractValidator<CreateAreaCommand>
    {
        public CreateAreaValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name can't be empty");
        }
    }
}
