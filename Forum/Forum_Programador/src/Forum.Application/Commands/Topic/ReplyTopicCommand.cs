using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.Topic
{
    public class ReplyTopicCommand : Command
    {
        public Guid Id { get; private set; }

        public Guid TopicId { get; private set; }

        public Guid UserId { get; private set; }

        public string Text { get; private set; }

        public ReplyTopicCommand(Guid id,Guid topicId, Guid userId, string text)
        {
            Id = id;
            TopicId = topicId;
            UserId = userId;
            Text = text;
            AggregateId = id;

        }

        public override bool IsValid()
        {
            ValidationResult = new ReplyTopicValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }


    public class ReplyTopicValidator : AbstractValidator<ReplyTopicCommand>
    {
        public ReplyTopicValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid Id Topic.");
            RuleFor(x => x.TopicId).NotEqual(Guid.Empty).WithMessage("Invalid Id Section.");
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("Invalid Id User.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("The text can't be empety.");
        }
    }
}
