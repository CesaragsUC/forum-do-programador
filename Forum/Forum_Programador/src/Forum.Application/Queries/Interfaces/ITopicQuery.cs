using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface ITopicQuery
    {
        Task<TopicDTO> GetById(Guid id);
        Task<IEnumerable<TopicDTO>> GetAll();
        Task<IEnumerable<TopicDTO>> GetBySectionId(Guid sectionId);
    }
}
