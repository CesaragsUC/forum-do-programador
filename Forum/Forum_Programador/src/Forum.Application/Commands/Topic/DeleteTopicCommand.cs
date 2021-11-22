using FluentValidation;
using Forum.Core.Messages;
using Forum.Domain.Entities;
using System;

namespace Forum.Application.Commands
{
    public class DeleteTopicCommand : Command
    {
        public Guid Id { get; private set; }

        public DeleteTopicCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
   
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteTopicValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class DeleteTopicValidation : AbstractValidator<DeleteTopicCommand>
    {
        public DeleteTopicValidation()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty)
                .WithMessage("The topic id is invalid.");
        }
    }
}
