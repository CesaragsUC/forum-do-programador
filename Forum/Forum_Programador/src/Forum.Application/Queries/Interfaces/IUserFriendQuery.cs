using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface IUserFriendQuery
    {
        Task<IEnumerable<UserFriendDTO>> GetByUserId(Guid userId);
        Task<IEnumerable<UserFriendDTO>> GetAll();
    }
}
