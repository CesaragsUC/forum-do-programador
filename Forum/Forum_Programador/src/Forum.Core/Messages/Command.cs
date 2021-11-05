using FluentValidation.Results;
using MediatR;
using System;

namespace Forum.Core.Messages
{
    public abstract class Command : Message,IRequest<bool>
    {
        public DateTime TimeStamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            TimeStamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            throw new NotFiniteNumberException();
        }

    }
}
