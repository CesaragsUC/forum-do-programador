using System;
using System.ComponentModel;

namespace Forum.Domain
{
    public class UserForumType
    {
        public enum UserType
        {
            [Description("Admin")]
            Admin = 0,
            [Description("Moderator")]
            Modder = 1,
            [Description("Default")]
            Default = 2

        }
    }
}
