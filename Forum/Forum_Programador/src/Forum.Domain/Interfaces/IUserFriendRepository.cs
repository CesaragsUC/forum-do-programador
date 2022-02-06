using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface IUserFriendRepository : IRepository<UserFriends>
    {
        public void Add(UserFriends userFriends);
        public void Delete(UserFriends userFriends);
        public void Update(UserFriends userFriends);
        Task<UserFriends> GetById(Guid id);
        Task<IEnumerable<UserFriends>> GetByUserAndFriendId(Guid userId, Guid friendId);
        Task<IEnumerable<UserFriends>> GetByUserId(Guid userId);
        Task<IEnumerable<UserFriends>> GetAll();
    }
}
