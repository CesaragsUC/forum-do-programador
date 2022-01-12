using Forum.Core.Messages;
using System;

namespace Forum.Application.Events.UserFriend
{
    public class UserFriendEvent : Event
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid UserToFollowId { get; private set; }

        public UserFriendEvent(Guid id , Guid userId, Guid usertoFollowId)
        {
            Id = id;
            UserId = userId;
            UserToFollowId = usertoFollowId;
            AggregateId = id;
        }

    }
}
