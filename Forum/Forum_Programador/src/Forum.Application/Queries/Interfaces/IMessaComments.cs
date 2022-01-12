using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface IMessaCommentsQuery
    {
        Task<IEnumerable<MessageCommentDTO>> GetByMessageId(Guid messageId);
        Task<IEnumerable<MessageCommentDTO>> GetByUserId(Guid userId);
        Task<IEnumerable<MessageCommentDTO>> GetAll();

    }
}
