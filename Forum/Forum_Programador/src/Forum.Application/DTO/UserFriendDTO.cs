using System;

namespace Forum.Application.DTO
{
    public class UserFriendDTO
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid FriendId { get; private set; }
        public DateTime CreationDate { get; private set; }

        public UserDTO User { get; private set; }
        public UserDTO Friend { get; private set; } //His friend
    }
}
