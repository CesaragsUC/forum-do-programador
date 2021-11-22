using FluentValidation;
using Forum.Core.Messages;
using Forum.Domain.Entities;
using System;

namespace Forum.Application.Commands
{
    public class CreateTopicCommand : Command
    {
        public string Title { get; private set; }
        public Guid UserId { get; private set; }
        public Guid SectionId { get; private set; }

        public string Text { get; private set; }

        public CreateTopicCommand(string title,string text, Guid userId, Guid sectionId)
        {
            UserId = userId;
            SectionId = sectionId;
            Title = title;
            Text = text;
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
            RuleFor(x => x.Title).NotEmpty().WithMessage("The topic name can't be empty.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("The topic text can't be empty.");
            RuleFor(x => x.UserId).NotEqual(Guid.Empty)
                .WithMessage("The user id is invalid.");
        }
    }
}
