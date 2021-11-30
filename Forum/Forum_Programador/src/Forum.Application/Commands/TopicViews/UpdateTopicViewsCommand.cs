using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.TopicViews
{
    public class UpdateTopicViewsCommand : Command
    {
        public Guid Id { get; private set; }
        public Guid TopicId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime ViewDate { get; private set; }

        public UpdateTopicViewsCommand(Guid id, Guid topicId, Guid userId)
        {
            Id = id;
            TopicId = topicId;
            UserId = userId;
            ViewDate = DateTime.Now;
            AggregateId = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateTopicViewsValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }

    public class UpdateTopicViewsValidator : AbstractValidator<UpdateTopicViewsCommand>
    {
        public UpdateTopicViewsValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("Invalid UserId.");
            RuleFor(x => x.TopicId).NotEqual(Guid.Empty).WithMessage("Invalid  TopicId.");
        }

    }
}
