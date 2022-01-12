using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Forum.Core.Messages;

namespace Forum.Application.Commands.PrivateMessages
{
    public class AddMessagesCommentCommand : Command
    {
        public Guid UserId { get; private set; }
        public Guid PrivateMessageId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsSeen { get; private set; }
        public string Text { get; private set; }

        public AddMessagesCommentCommand(Guid userId,Guid privateMessageId,string text)
        {
            UserId = userId;
            Text = text;
            PrivateMessageId = privateMessageId;
            IsSeen = false;
            CreationDate = DateTime.Now;
           
        }

        public override bool IsValid()
        {

            ValidationResult = new AddMessagesCommentValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddMessagesCommentValidator : AbstractValidator<AddMessagesCommentCommand>
    {
        public AddMessagesCommentValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("Invalid User ID");
            RuleFor(x => x.PrivateMessageId).NotEqual(Guid.Empty).WithMessage("PrivateMessage");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Message content can't be empty.");
        }
    }

}
