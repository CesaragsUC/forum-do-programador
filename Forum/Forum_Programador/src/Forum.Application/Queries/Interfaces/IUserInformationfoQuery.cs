using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface IUserInformationfoQuery
    {
        Task<UserInformationDTO> GetByUserId(Guid userId);
        Task<IEnumerable<UserInformationDTO>> GetAll();
    }
}
