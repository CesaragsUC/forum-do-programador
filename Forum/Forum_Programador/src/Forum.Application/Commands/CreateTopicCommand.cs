using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands
{
    public class CreateTopicCommand : Command
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public CreateTopicCommand(string name, Guid userId)
        {
            UserId = userId;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateTopicValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CreateTopicValidation : AbstractValidator<CreateTopicCommand>
    {
        public CreateTopicValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The topic name can't be empty.");

            RuleFor(x => x.UserId).NotEqual(Guid.Empty)
                .WithMessage("The user id is invalid.");
        }
    }
}
