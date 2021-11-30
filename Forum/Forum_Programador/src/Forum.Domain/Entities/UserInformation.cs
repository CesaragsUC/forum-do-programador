using Forum.Core.DomainObjects;
using System;

namespace Forum.Domain.Entities
{
    public class UserInformation : Entity, IAggregateRoot
    {
        public Guid UserId { get; private set; }

        public string WebSite { get; private set; }
        public string GitHub { get; private set; }
        public string Twitter { get; private set; }
        public string Instagran { get; private set; }
        public string FaceBook { get; private set; }
        public string NickName { get; private set; }
        public string FullName { get; private set; }
        public string Adress { get; private set; }

        public string Occupation { get; private set; }

        //EF
        public User User { get; private set; }

        public UserInformation(Guid userId, string website,string github,string twitter, string instagran,
                string facebook,string nickname,string fullname,string occupation, string adress)
        {
            UserId = userId;
            WebSite = website;
            GitHub = github;
            Twitter = twitter;
            Instagran = instagran;
            FaceBook = facebook;
            NickName = nickname;
            FullName = fullname;
            Adress = adress;
            Occupation = occupation;

        }
        protected UserInformation()
        {

        }

        public void UpdateInformation(UserInformation information)
        {
            WebSite = information.WebSite;
            GitHub = information.GitHub;
            Twitter = information.Twitter;
            Instagran = information.Instagran;
            FaceBook = information.FaceBook;
            FullName = information.FullName;
            Adress = information.Adress;
        }
    }
}
