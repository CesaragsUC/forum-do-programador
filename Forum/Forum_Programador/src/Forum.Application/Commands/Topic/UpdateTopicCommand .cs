using FluentValidation;
using Forum.Core.Messages;
using Forum.Domain.Entities;
using System;

namespace Forum.Application.Commands
{
    public class UpdateTopicCommand : Command
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public Guid UserId { get; private set; }
        public Guid SectionId { get; private set; }
        public string Text { get; private set; }

        public UpdateTopicCommand(Guid id, string title,string text, Guid userId, Guid sectionId)
        {
            Id = id;
            UserId = userId;
            SectionId = sectionId;
            Title = title;
            Text = text;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateTopicValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateTopicValidation : AbstractValidator<UpdateTopicCommand>
    {
        public UpdateTopicValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("The topic Title can't be empty.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("The topic text can't be empty.");
            RuleFor(x => x.SectionId).NotEqual(Guid.Empty).WithMessage("The topic SectionId can't be empty.");
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("The topic UserId can't be empty.");

            RuleFor(x => x.UserId).NotEqual(Guid.Empty)
                .WithMessage("The user id is invalid.");
        }
    }
}
