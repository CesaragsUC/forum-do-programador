using Forum.Core.DomainObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string FullName { get; private set; }
        public string Adress { get; private set; }

        public string Occupation { get; private set; }

        public User User { get; private set; }

        public UserInformation(Guid userId, string website,string github,string twitter, string instagran,
                string facebook,string fullname,string occupation, string adress)
        {
            UserId = userId;
            WebSite = website;
            GitHub = github;
            Twitter = twitter;
            Instagran = instagran;
            FaceBook = facebook;
            FullName = fullname;
            Adress = adress;
            Occupation = occupation;

        }
        protected UserInformation()
        {

        }

        public void UpdateInformation(Guid id,Guid userId, string site,string github, string twiteer, string instagran,
            string facebook, string fullname,  string occupation, string adress)
        {
            Id = id;
            UserId = userId;
            WebSite = site;
            GitHub = github;
            Twitter = twiteer;
            Instagran = instagran;
            FaceBook = facebook;
            FullName = fullname;
            Adress = adress;
            Occupation = occupation;
           
        }
    }
}
