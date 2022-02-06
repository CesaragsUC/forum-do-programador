using Forum.Application.DTO;
using Forum.Application.Queries.Helpers;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Application.Queries
{
    public class CommentQuery : ICommentQuery
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;

        public CommentQuery(ITopicRepository topicRepository,
            IUserRepository userRepository,
            ICommentRepository commentRepository)
        {
            _topicRepository = topicRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<CommentsDTO>> GetAll()
        {
            var comments = await _commentRepository.GetAll();

            var commentList = new List<CommentsDTO>();

            foreach (var c in comments)
            {
                var comment = new CommentsDTO
                {
                    Id = c.Id,
                    CommentId = c.CommentId,
                    CreationDate = c.CreationDate,
                    Text = c.Text,
                    TopicId = c.TopicId,
                    UserId = c.UserId,
                    TimeAgo = TimeAgo.GetTimeAgo(c.CreationDate),
                    Point = c.Point,
                    UserSendPointId = c.UserSendPointId
                };
                commentList.Add(comment);
            }

            return commentList;
        }

        public async Task<CommentsDTO> GetById(Guid id)
        {
            var comment =  await _commentRepository.GetById(id);

            var commentDTO = new CommentsDTO
            {
                Id = comment.Id,
                CommentId = comment.CommentId,
                CreationDate = comment.CreationDate,
                Text = comment.Text,
                TopicId = comment.TopicId,
                UserId = comment.UserId,
                Point = comment.Point,
                UserSendPointId = comment.UserSendPointId
            };

            return commentDTO;

        }

        public async Task<IEnumerable<CommentsDTO>> GetByTopicId(Guid topicId,Guid loggedUserId)
        {
            var comments = await _commentRepository.GetByTopicId(topicId);

            var commentList = new List<CommentsDTO>();

            foreach (var c in comments)
            {
                var comment = new CommentsDTO
                {
                    Id = c.Id,
                    CommentId = c.CommentId,
                    CreationDate = c.CreationDate,
                    Text = c.Text,
                    TopicId = c.TopicId,
                    UserId = c.UserId,
                    TimeAgo = TimeAgo.GetTimeAgo(c.CreationDate),
                    CanEdit = c.UserId == loggedUserId ? true : false,
                    Point = c.Point,
                    UserSendPointId = c.UserSendPointId
                };

                var topic = new TopicDTO
                {
                    Id = c.Topic.Id,
                    Title = c.Topic.Title,
                    CreationDate = c.Topic.CreationDate
                    
                };

                var user = new UserDTO
                {
                    Id = c.User.Id,
                    Name = c.User.Name,
                    Email = c.User.Email,
                    IdentityId = c.User.IdentityId,
                    LastActivity = c.User.LastActivity,
                    UserTypeId = c.User.UserTypeId,
                    CreationDate = c.User.CreationDate,
                    Avatar = c.User.Avatar
                };

                comment.User = user;
                comment.Topic = topic;

                commentList.Add(comment);

            }

            return commentList.OrderBy(x=>x.CommentId);
        }
    }
}
