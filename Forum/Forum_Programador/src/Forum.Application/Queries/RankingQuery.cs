using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries
{
    public class RankingQuery : IRankingQuery
    {

        public RankingQuery()
        {

        }
        public Task<IEnumerable<RankingDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RankingDTO> GetByCommentId(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public Task<RankingDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RankingDTO> GetByTopicId(Guid topicId)
        {
            throw new NotImplementedException();
        }

        public Task<RankingDTO> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
