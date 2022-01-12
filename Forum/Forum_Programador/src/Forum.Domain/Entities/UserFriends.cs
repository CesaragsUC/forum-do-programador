using Forum.Core.DomainObjects;
using System;

namespace Forum.Domain.Entities
{
    public class UserFriends : Entity, IAggregateRoot
    {
        public Guid UserId { get;private set; }
        public Guid FriendId { get; private set; }
        public DateTime CreationDate { get; private set; }

        public User User { get; private set; }
        public User Friend { get; private set; }
        public bool IsSeen { get; private set; }

        public UserFriends(Guid userId, Guid friendId)
        {
            UserId = userId;
            FriendId = friendId;
        }
        protected UserFriends()
        {

        }
        public void UpdateUserFriend(Guid userId, Guid friendId)
        {
            UserId = userId;
            FriendId = friendId;
        }
    }
}
