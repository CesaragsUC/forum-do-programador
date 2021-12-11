using System;

namespace Forum.Application.DTO
{
    public class UserFriendDTO
    {
        public Guid Id { get;  set; }
        public Guid UserId { get;  set; }
        public Guid FriendId { get;  set; }//His friend ID
        public DateTime CreationDate { get;  set; }

        public UserDTO User { get;  set; }
        public UserDTO Friend { get;  set; } //His friend
    }
}
