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
        public void Delete(Ranking topic);
        public void Update(Ranking topic);
        Task<User> GetById(Ranking id);
        Task<IEnumerable<Ranking>> GetAll();
        Task<IEnumerable<Ranking>> GetByUserId();
        Task<IEnumerable<Ranking>> GetByCommentId();
        Task<IEnumerable<Ranking>> GetByTopicId();
    }
}
