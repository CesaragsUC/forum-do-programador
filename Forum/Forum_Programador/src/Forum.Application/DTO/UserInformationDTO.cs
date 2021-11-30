using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class UserInformationDTO
    {
        public Guid Id { get;  set; }
        public Guid UserId { get;  set; }

        public string WebSite { get;  set; }
        public string GitHub { get;  set; }
        public string Twitter { get;  set; }
        public string Instagran { get;  set; }
        public string FaceBook { get;  set; }

        [Required(ErrorMessage ="The {0} is required")]
        [MaxLength(20)]
        public string NickName { get;  set; }

        [Required(ErrorMessage = "The {0} is required")]
        [MaxLength(50)]
        public string FullName { get;  set; }

        [MaxLength(100)]
        public string Adress { get;  set; }

        [Required(ErrorMessage = "The {0} is required")]
        [MaxLength(50)]
        public string Occupation { get;  set; }

 
        public UserDTO User { get;  set; }
    }
}
