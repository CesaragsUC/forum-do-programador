using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTO
{
    public class UserInformationDTO
    {
        public UserInformationDTO()
        {
            UserFriend = new List<UserFriendDTO>();
        }
        public Guid Id { get;  set; }
        public Guid UserId { get;  set; }

        public string WebSite { get;  set; }
        public string GitHub { get;  set; }
        public string Twitter { get;  set; }
        public string Instagran { get;  set; }
        public string FaceBook { get;  set; }

        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "The {0} is required")]
        [MaxLength(50)]
        public string FullName { get;  set; }

        [MaxLength(100)]
        public string Adress { get;  set; }

        [Required(ErrorMessage = "The {0} is required")]
        [MaxLength(50)]
        public string Occupation { get;  set; }


        public List< UserFriendDTO> UserFriend { get; set; }
        public UserDTO User { get;  set; }

        public UpdateUserAvatarDTO UpdateUserAvatar { get; set; }

        public UpdateUserPasswordDTO UpdateUserPassword { get; set; }
    }
}
