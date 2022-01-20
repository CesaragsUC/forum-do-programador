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
        public void AddMessageComment(MessageComment messageComment);
        public void Delete(PrivateMessages message);
        public void Update(PrivateMessages message);
        public void UpdateMessageComment(MessageComment messageComment);
        Task<PrivateMessages> GetById(Guid msgId);
        Task<IEnumerable<PrivateMessages>> GetBySubject(string subject);
        Task<IEnumerable<PrivateMessages>> GetBySenderyId(Guid senderId);
        Task<IEnumerable<PrivateMessages>> GetByRecipientId(Guid userId);
        Task<IEnumerable<PrivateMessages>> GetByRecipientOrSenderId(Guid userId);
        Task<IEnumerable<PrivateMessages>> GetAll();
    }
}
