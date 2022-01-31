using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface IRankingQuery
    {
        Task<RankingDTO> GetById(Guid id);
        Task<IEnumerable<RankingDTO>> GetByUserId(Guid userId);
        Task<IEnumerable<RankingDTO>> GetByTopicId(Guid topicId);
        Task<IEnumerable<RankingDTO>> GetByCommentId(Guid commentId);
        Task<IEnumerable<RankingDTO>> GetAll();
        int TotalUserScore (Guid userid);
    }
}

