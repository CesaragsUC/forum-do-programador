using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface ITopicViewsQuery
    {
        Task<TopicViewsDTO> GetById(Guid id);
        Task<IEnumerable<TopicViewsDTO>> GetByTopicId(Guid topicId);
        Task<IEnumerable<TopicViewsDTO>> GetByUserId(Guid userId);
        Task<IEnumerable<TopicViewsDTO>> GetAll();
    }
}
