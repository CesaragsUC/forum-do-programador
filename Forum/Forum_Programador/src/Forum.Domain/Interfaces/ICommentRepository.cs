using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface ICommentRepository : IRepository<Comments>
    {
        Task<Comments> GetById(Guid id);
        Task<IEnumerable<Comments>> GetByTopicId(Guid topicid);
        Task<IEnumerable<Comments>> GetAll();
        void Add(Comments section);
        void Update(Comments section);
        void Delete(Comments section);
    }
}
