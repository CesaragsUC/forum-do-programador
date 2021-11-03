using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public Guid IdentityId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public string Avatar { get; private set; }

        public int UserTypeId { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime LastActivity { get; private set; }
    }
}
