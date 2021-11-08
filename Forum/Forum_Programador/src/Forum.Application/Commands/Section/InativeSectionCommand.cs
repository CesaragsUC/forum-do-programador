using FluentValidation;
using Forum.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Commands.Section
{
    public class InativeSectionCommand : Command    {

        public Guid Id { get; private set; }
        public bool IsActive { get; private set; }

        public InativeSectionCommand(Guid id,bool active)
        {
            Id = id;
            IsActive = active;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new InativeSectionValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class InativeSectionValidation : AbstractValidator<InativeSectionCommand>
    {
        public InativeSectionValidation()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Id cant be null");
        }
    }
}
