using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries
{
    public class TopicViewsQuery : ITopicViewsQuery
    {
        private readonly ITopicViewsRepository _topicViewsRepository;
        private readonly IUserRepository _userRepository;

        public TopicViewsQuery(ITopicViewsRepository topicViewsRepository,
            IUserRepository userRepository)
        {
            _topicViewsRepository = topicViewsRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<TopicViewsDTO>> GetAll()
        {
            var topicViews = await _topicViewsRepository.GetAll();

            var topicViewsDTO = new List<TopicViewsDTO>();

            foreach (var topicview in topicViews)
            {
                var tpw = new TopicViewsDTO
                {
                    Id = topicview.Id,
                    TopicId = topicview.TopicId,
                    UserId = topicview.UserId,
                    ViewDate = topicview.ViewDate
                };

                topicViewsDTO.Add(tpw);
            }

            return topicViewsDTO;
        }

        public async Task<TopicViewsDTO> GetById(Guid id)
        {
            var topicViews = await _topicViewsRepository.GetById(id);

            var topicViewsDTO = new TopicViewsDTO
            {
                Id = topicViews.Id,
                TopicId = topicViews.TopicId,
                UserId = topicViews.UserId,
                ViewDate = topicViews.ViewDate
            };
            return topicViewsDTO;
        }


        public async Task<IEnumerable<TopicViewsDTO>> GetByTopicId(Guid topicId)
        {
            var topicViews = await _topicViewsRepository.GetByTopicId(topicId);

            var topicViewsDTO = new List<TopicViewsDTO>();

            foreach (var topicview in topicViews)
            {
                var tpw = new TopicViewsDTO
                {
                    Id = topicview.Id,
                    TopicId = topicview.TopicId,
                    UserId = topicview.UserId,
                    ViewDate = topicview.ViewDate
                };

                topicViewsDTO.Add(tpw);
            }

            return topicViewsDTO;
        }

        public async Task<IEnumerable<TopicViewsDTO>> GetByUserId(Guid userId)
        {
            var topicViews = await _topicViewsRepository.GetByUserId(userId);

            var topicViewsDTO = new List<TopicViewsDTO>();

            foreach (var topicview in topicViews)
            {
                var tpw = new TopicViewsDTO
                {
                    Id = topicview.Id,
                    TopicId = topicview.TopicId,
                    UserId = topicview.UserId,
                    ViewDate = topicview.ViewDate
                };

                topicViewsDTO.Add(tpw);
            }

            return topicViewsDTO;
        }

    }
}
