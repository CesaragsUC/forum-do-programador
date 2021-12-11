using FluentValidation;
using Forum.Core.Messages;
using System;

namespace Forum.Application.Commands.UserInfo
{
    public class AddUserInformationCommand : Command
    {
        public Guid UserId { get; private set; }

        public string WebSite { get; private set; }
        public string GitHub { get; private set; }
        public string Twitter { get; private set; }
        public string Instagran { get; private set; }
        public string FaceBook { get; private set; }
        public string FullName { get; private set; }
        public string Adress { get; private set; }
        public string Email { get; private set; }

        public string Occupation { get; private set; }

        public AddUserInformationCommand(Guid userId, string website, string guithub,
            string twitter,string instagran,
            string facebook, string fullname,string adress,string ocupation
            ,string email)
        {
            UserId = userId;
            WebSite = website;
            GitHub = guithub;
            Twitter = twitter;
            Instagran = instagran;
            FaceBook = facebook;
            FullName = fullname;
            Adress = adress;
            Occupation = ocupation;
            Email = email;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddUserInformationValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class AddUserInformationValidation : AbstractValidator<AddUserInformationCommand>
    {
        public AddUserInformationValidation()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("Invalid UserId.");
            RuleFor(x => x.Occupation).NotEqual(string.Empty).WithMessage("Invalid Occupation.");
            RuleFor(x => x.Email).NotEqual(string.Empty).EmailAddress().WithMessage("Invalid Email.");

        }

    }
}
