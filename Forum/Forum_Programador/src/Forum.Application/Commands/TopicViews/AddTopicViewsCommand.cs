using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.TopicViews
{
    public class AddTopicViewsCommand : Command
    {
        public Guid TopicId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime ViewDate { get; private set; }

        public AddTopicViewsCommand(Guid topicId, Guid userId)
        {
            TopicId = topicId;
            UserId = userId;
            ViewDate = DateTime.Now;
        }
        public override bool IsValid()
        {
            ValidationResult = new AddTopicViewsValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddTopicViewsValidator : AbstractValidator<AddTopicViewsCommand>
    {
        public AddTopicViewsValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("Invalid UserId.");
            RuleFor(x => x.TopicId).NotEqual(Guid.Empty).WithMessage("Invalid  TopicId.");
        }

    }
}
