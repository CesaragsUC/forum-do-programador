using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface ITopicViewsRepository : IRepository<TopicViews>
    {
        public void Add(TopicViews topicViews);
        public void Delete(TopicViews topicViews);
        public void Update(TopicViews topicViews);
        Task<TopicViews> GetById(Guid id);
        Task<IEnumerable<TopicViews>> GetByTopicId(Guid topicId);
        Task<IEnumerable<TopicViews>> GetByUserId(Guid userId);
        Task<IEnumerable<TopicViews>> GetByUserAndTopicId(Guid topicId, Guid userId);
        Task<IEnumerable<TopicViews>> GetAll();
    }
}
