using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.ReportUser
{
    public class AddReportCommand : Command
    {
        public Guid UserSendReportId { get; private set; }
        public Guid UserId { get; private set; }
        public string Reason { get; private set; }

        public AddReportCommand(Guid userSendReportId,Guid userId,string reason)
        {
            UserSendReportId = userSendReportId;
            UserId = userId;
            Reason = reason;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddReportValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddReportValidation : AbstractValidator<AddReportCommand>
    {
        public AddReportValidation()
        {
            RuleFor(x => x.UserSendReportId).NotEqual(Guid.Empty).WithMessage("User that send report can't be null");
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("User  reported can't be null");
            RuleFor(x => x.Reason).NotEmpty().NotNull().WithMessage("The reason report can't be null");
        }
    }
}
