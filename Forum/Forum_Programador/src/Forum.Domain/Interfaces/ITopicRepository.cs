using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface ITopicRepository: IRepository<Topic>
    {
        Task<Topic> GetById(Guid id);
        Task<IEnumerable<Topic>> GetBySectionId(Guid sectionId);
        Task<Topic> GetByUserId(Guid userId);
        Task<IEnumerable<Topic>> GetAll();
        void Add(Topic topic);
        void AddComment(Comments comment);
        void Update(Topic topic);
        void Delete(Topic topic);
    }
}
