using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface IRankingRepository : IRepository<Ranking>
    {
        public void Add(Ranking topic);
        public void UpdateCommentPoint(Comments comment);
        public void Delete(Ranking topic);
        public void Update(Ranking topic);
        Task<Ranking> GetById(Guid id);
        Task<IEnumerable<Ranking>> GetAll();
        Task<IEnumerable<Ranking>> GetByUserId(Guid userId);
        Task<Ranking> GetByCommentAndUserId(Guid commentId, Guid userSenderId);
        Task<Ranking> GetByCommentId(Guid commentId);
        Task<IEnumerable<Ranking>> GetByTopicId(Guid topicid);

    }
}
