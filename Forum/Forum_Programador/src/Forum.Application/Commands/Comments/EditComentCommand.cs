using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.Comments
{
    public class EditComentCommand : Command
    {
        public Guid Id { get; private set; }
        public Guid TopicId { get; private set; }

        public Guid UserId { get; private set; }

        public string Text { get; private set; }

        public EditComentCommand(Guid id,Guid topicId, string text)
        {
            Id = id;
            TopicId = topicId;
            Text = text;
            AggregateId = id;

        }

        public override bool IsValid()
        {
            ValidationResult = new EditComentValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }
    public class  EditComentValidator : AbstractValidator<EditComentCommand>
    {
        public EditComentValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid Id Commnet.");
            RuleFor(x => x.TopicId).NotEqual(Guid.Empty).WithMessage("Invalid  TopicId.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("The text can't be empety.");
        }

    }
}
