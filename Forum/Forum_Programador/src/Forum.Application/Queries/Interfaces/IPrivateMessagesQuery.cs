using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface IPrivateMessagesQuery
    {
        Task<PrivateMessagesDTO> GetById(Guid id);
        Task<IEnumerable<PrivateMessagesDTO>> GetBySubject(string subject);
        Task<IEnumerable<PrivateMessagesDTO>> GetBySenderyId(Guid senderId);
        Task<IEnumerable<PrivateMessagesDTO>> GetByRecipientId(Guid userId);
        Task<IEnumerable<PrivateMessagesDTO>> GetAll();
    }
}
