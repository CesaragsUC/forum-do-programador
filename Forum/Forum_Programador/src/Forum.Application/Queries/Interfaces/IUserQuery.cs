using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface IUserQuery
    {
        Task<UserDTO> GetById(Guid id);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetByIdentityId(Guid identityId);
        Task<UserDTO> GetByNameAndEmail(string name, string email);
        
    }
}
