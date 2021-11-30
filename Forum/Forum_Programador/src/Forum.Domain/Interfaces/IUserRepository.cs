using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public void Add(User topic);
        public void Delete(User topic);
        public void Update(User topic);
        Task<User> GetById(Guid id);
        Task<User> GetByIdentityId(Guid identityId);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByNameAndEmail(string name, string email);
    }
}
