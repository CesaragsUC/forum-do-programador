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

        public string Title { get; private set; }

        public Guid UserId { get; private set; }

        public DateTime CreationDate { get; private set; }

        public UserDTO User { get; private set; }


        public ICollection<CommentsDTO> Coments { get; private set; }
    }
}
