using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.TopicViews
{
    public class DeleteTopicViewsCommand : Command
    {
        public Guid Id { get; private set; }
        public DeleteTopicViewsCommand(Guid id)
        {
            Id = id;
            AggregateId = id;

        }
    }

    public class DeleteTopicViewsValidator : AbstractValidator<UpdateTopicViewsCommand>
    {
        public DeleteTopicViewsValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Invalid Id.");
        }

    }
}
