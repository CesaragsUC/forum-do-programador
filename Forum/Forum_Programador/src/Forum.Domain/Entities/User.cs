using Forum.Core.DomainObjects;
using Forum.Domain.Extensions;
using System;

namespace Forum.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {

        public Guid IdentityId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }

        public bool IsBanned { get; private set; }

        public string Avatar { get; private set; }

        public int UserTypeId { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime LastActivity { get; private set; }


        public User(Guid identityId, string name,string email,string avatar,int usertypeId)
        {
            IdentityId = identityId;
            Name = name;
            Email = email;
            Avatar = avatar;
            UserTypeId = usertypeId;
            IsActive = true;
        }

        protected User()
        {

        }

        public bool IsValidEmail(string email)
        {
            return ValidateEmail.IsValidEmail( email);
        }

        public void SetUserType(int _type)
        {
            UserTypeId = _type;
        }


        public void UpdateLastActivity()
        {
            LastActivity = DateTime.Now;
        }

        public void Update( int usertypeId, bool active)
        {

            UserTypeId = usertypeId;
            IsActive = active;
           
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdateAvatar(string avatar)
        {
            Avatar = avatar;
        }

        public void BanUser()
        {
            IsBanned = true;
        }
        public void UnBanUser()
        {
            IsBanned = false;
        }
    }
}
