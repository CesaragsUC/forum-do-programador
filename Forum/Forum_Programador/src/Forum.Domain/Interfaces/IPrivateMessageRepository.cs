using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface IPrivateMessageRepository : IRepository<PrivateMessages>
    {
        public void Add(PrivateMessages message);
        public void Delete(PrivateMessages message);
        public void Update(PrivateMessages message);
        Task<PrivateMessages> GetById(Guid id);
        Task<PrivateMessages> GetBySubject(string subject);
        Task<PrivateMessages> GetBySenderyId(Guid senderId);
        Task<PrivateMessages> GetByRecipientId(Guid recipientId);
        Task<IEnumerable<PrivateMessages>> GetAll();
    }
}
