using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Forum.Core.Messages;

namespace Forum.Application.Commands.Ranking
{
    public class RemoveScoreCommand : Command
    {
        public Guid UserId { get; private set; }

        public Guid TopicId { get; private set; }

        public Guid CommentId { get; private set; }

        public RemoveScoreCommand(Guid userId,Guid topicId, Guid commentId)
        {
            UserId = userId;
            TopicId = topicId;
            CommentId = commentId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveScoreCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoveScoreCommandValidation : AbstractValidator<RemoveScoreCommand>
    {
        public RemoveScoreCommandValidation()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("UserId can't be null");
            RuleFor(x => x.TopicId).NotEqual(Guid.Empty).WithMessage("Topic can't be null");
            RuleFor(x => x.CommentId).NotEqual(Guid.Empty).WithMessage("CommentId can't be null");
        }
    }
}
