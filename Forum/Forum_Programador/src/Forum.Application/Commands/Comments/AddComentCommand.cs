using FluentValidation;
using Forum.Core.Messages;
using System;
namespace Forum.Application.Commands.Comments
{
    public class  AddComentCommand : Command
    {
        public Guid TopicId { get; private set; }

        public Guid UserId { get; private set; }

        public string Text { get; private set; }

        public AddComentCommand(Guid topicId, Guid userId, string text)
        {

            TopicId = topicId;
            UserId = userId;
            Text = text;

        }

        public override bool IsValid()
        {
            ValidationResult = new AddComentValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }

    public class AddComentValidator : AbstractValidator<AddComentCommand>
    {
        public AddComentValidator()
        {
            RuleFor(x => x.TopicId).NotEqual(Guid.Empty).WithMessage("Invalid Id Section.");
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("Invalid Id User.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("The text can't be empety.");
        }
    }
}
