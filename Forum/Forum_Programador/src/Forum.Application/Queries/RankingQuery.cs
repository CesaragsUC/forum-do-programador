using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Domain.Interfaces;

namespace Forum.Application.Queries
{
    public class RankingQuery : IRankingQuery
    {

        private readonly IRankingRepository _rankingRepository;
        public RankingQuery(IRankingRepository rankingRepository)
        {
            _rankingRepository = rankingRepository;
        }

        public async Task<IEnumerable<RankingDTO>> GetAll()
        {
            var rankList = await _rankingRepository.GetAll();

            var result = new List<RankingDTO>();

            foreach (var rank in rankList)
            {
                var data = new RankingDTO
                {
                    CommentId = rank.CommentId,
                    CreationDate = rank.CreationDate,
                    Id = rank.Id,
                    Point = rank.Point,
                    TopicId = rank.TopicId,
                    UserId = rank.UserId,
                    UserSentPointId = rank.UserSentId

                };

                result.Add(data);
            }

            return result;
        }

        public int TotalUserScore(Guid userid)
        {
            var rank = _rankingRepository.GetByUserId(userid).Result;

            var total = rank.Sum(x => x.Point);
            return total;
        }

        public async Task<RankingDTO> GetByCommentId(Guid commentId)
        {
            var rank = await _rankingRepository.GetByCommentId(commentId);


            var data = new RankingDTO
            {
                CommentId = rank.CommentId,
                CreationDate = rank.CreationDate,
                Id = rank.Id,
                Point = rank.Point,
                TopicId = rank.TopicId,
                UserId = rank.UserId,
                UserSentPointId = rank.UserSentId

            };


            return data;
        }

        public async Task<RankingDTO> GetById(Guid id)
        {
            var rank = await _rankingRepository.GetById(id);

            var data = new RankingDTO
            {
                CommentId = rank.CommentId,
                CreationDate = rank.CreationDate,
                Id = rank.Id,
                Point = rank.Point,
                TopicId = rank.TopicId,
                UserId = rank.UserId,
                UserSentPointId = rank.UserSentId

            };
            return data;
        }

        public async Task<IEnumerable<RankingDTO>> GetByTopicId(Guid topicId)
        {
            var rankList = await _rankingRepository.GetByTopicId(topicId);

            var result = new List<RankingDTO>();

            foreach (var rank in rankList)
            {
                var data = new RankingDTO
                {
                    CommentId = rank.CommentId,
                    CreationDate = rank.CreationDate,
                    Id = rank.Id,
                    Point = rank.Point,
                    TopicId = rank.TopicId,
                    UserId = rank.UserId,
                    UserSentPointId = rank.UserSentId

                };

                result.Add(data);
            }

            return result;
        }

        public async Task<IEnumerable<RankingDTO>> GetByUserId(Guid userId)
        {
            var rankList = await _rankingRepository.GetByUserId(userId);

            var result = new List<RankingDTO>();

            foreach (var rank in rankList)
            {
                var data = new RankingDTO
                {
                    CommentId = rank.CommentId,
                    CreationDate = rank.CreationDate,
                    Id = rank.Id,
                    Point = rank.Point,
                    TopicId = rank.TopicId,
                    UserId = rank.UserId,
                    UserSentPointId = rank.UserSentId

                };

                result.Add(data);
            }

            return result;
        }
    }
}
