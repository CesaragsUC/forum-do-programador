using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface IMessageCommentRepository : IRepository<MessageComment>
    {
        Task<MessageComment> GetById(Guid id);
        Task<IEnumerable<MessageComment>> GetByMessageId(Guid messageId);
        Task<IEnumerable<MessageComment>> GetByUserId(Guid userId);
        Task<IEnumerable<MessageComment>> GetAll();
        void Add(MessageComment comment);
        void Update(MessageComment comment);
        void Delete(MessageComment comment);
    }
}
