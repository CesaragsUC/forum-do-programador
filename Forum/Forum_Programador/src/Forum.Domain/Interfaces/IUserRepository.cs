using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public void Add(User user);
        public void AddUserInformation(UserInformation userInformation);
        public void UpdateUserInformation(UserInformation userInformation);
        public void Delete(User user);
        public void Update(User user);
        Task<User> GetById(Guid userId);
        Task<User> GetByIdentityId(Guid identityId);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByNameAndEmail(string name, string email);
    }
}
