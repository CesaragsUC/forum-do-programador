using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class TopicDTO
    {
        public Guid Id { get; set; }

        public string Title { get;  set; }

        public Guid UserId { get;  set; }

        public DateTime CreationDate { get;  set; }

        public UserDTO User { get;  set; }


        public ICollection<CommentsDTO> Coments { get;  set; }
    }
}
