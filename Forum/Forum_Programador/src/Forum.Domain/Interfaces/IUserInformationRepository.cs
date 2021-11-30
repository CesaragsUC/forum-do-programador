using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface IUserInformationRepository : IRepository<UserInformation>
    {
        public void Add(UserInformation information);
        public void Delete(UserInformation information);
        public void Update(UserInformation information);
        Task<UserInformation> GetById(Guid id);
        Task<UserInformation> GetByUserId(Guid userId);
        Task<IEnumerable<UserInformation>> GetAll();
    }
}
