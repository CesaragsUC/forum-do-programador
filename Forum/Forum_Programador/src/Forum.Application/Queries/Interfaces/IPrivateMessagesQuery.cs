using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface IPrivateMessagesQuery
    {
        Task<PrivateMessagesDTO> GetById(Guid id);
        Task<PrivateMessagesDTO> GetBySubject(string subject);
        Task<PrivateMessagesDTO> GetBySenderyId(Guid senderId);
        Task<PrivateMessagesDTO> GetByRecipientId(Guid recipientId);
        Task<IEnumerable<PrivateMessagesDTO>> GetAll();
    }
}
