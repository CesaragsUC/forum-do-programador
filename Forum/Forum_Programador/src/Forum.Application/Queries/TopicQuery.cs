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
    public class TopicQuery : ITopicQuery
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;

        public TopicQuery(ITopicRepository topicRepository,
            IUserRepository userRepository,
            ICommentRepository commentRepository)
        {
            _topicRepository = topicRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<TopicDTO>> GetAll()
        {
            var topicList = await _topicRepository.GetAll();
            if (topicList == null) return null;

            var topics = new List<TopicDTO>();


            foreach (var item in topicList)
            {
                var comments = new List<CommentsDTO>();

                foreach (var cm in item.Coments)
                {
                    var coment = new CommentsDTO
                    {
                        Id = cm.Id,
                        CommentId = cm.CommentId,
                        CreationDate = cm.CreationDate,
                        Text = cm.Text,
                        TopicId = cm.TopicId,
                        UserId = cm.UserId
                    };

                    comments.Add(coment);
                }


                var userTopicModel = new UserDTO
                {
                    Id = item.User.Id,
                    Name = item.User.Name,
                    Email = item.User.Email,
                    IdentityId = item.User.IdentityId,
                    LastActivity = item.User.LastActivity,
                    UserTypeId = item.User.UserTypeId,
                    CreationDate = item.User.CreationDate,
                    Avatar = item.User.Avatar
                };

                var topicModel = new TopicDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    User = userTopicModel,
                    Coments = comments

                };

                topics.Add(topicModel);

            }

            return topics;


        }

        public async Task<TopicDTO> GetById(Guid id)
        {
            var topic = await _topicRepository.GetById(id);
            if (topic == null) return null;

            var userTopic = await _userRepository.GetById(topic.UserId);
            var commentsList = await _commentRepository.GetByTopicId(topic.Id);

            var comments = new List<CommentsDTO>();


            var userTopicModel = new UserDTO
            {
                Id = userTopic.Id,
                Name = userTopic.Name,
                Email = userTopic.Email,
                IdentityId = userTopic.IdentityId,
                LastActivity = userTopic.LastActivity,
                UserTypeId = userTopic.UserTypeId,
                CreationDate = userTopic.CreationDate,
                Avatar = userTopic.Avatar
            };

            foreach (var item in commentsList)
            {
                var coment = new CommentsDTO
                {
                    Id = item.Id,
                    CommentId = item.CommentId,
                    CreationDate = item.CreationDate,
                    Text = item.Text,
                    TopicId = item.TopicId,
                    UserId = item.UserId
                };

                comments.Add(coment);
            }
            var topicModel = new TopicDTO
            {
                Id = topic.Id,
                Title = topic.Title,
                User = userTopicModel,
                Coments = comments,
                SectionId = topic.SectionId
            };

            return topicModel;
        }

        public async Task<IEnumerable<TopicDTO>> GetBySectionId(Guid sectionId)
        {
            var topics = await _topicRepository.GetBySectionId(sectionId);
            if (!topics.Any()) return null;

            var comments = new List<CommentsDTO>();
            var topicList = new List<TopicDTO>();

            foreach (var t in topics)
            {
                var topic = new TopicDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    CreationDate = t.CreationDate,
                    UserId = t.UserId

                };

                var user = new UserDTO
                {
                    Id  = t.User.Id,
                    Name = t.User.Name,
                    CreationDate = t.User.CreationDate,
                    Email = t.User.Email,
                    Avatar = t.User.Avatar,
                    IdentityId = t.User.IdentityId,
                    LastActivity = t.User.LastActivity,
                    UserTypeId = t.User.UserTypeId

                };

                foreach (var c in t.Coments)
                {
                    var coment = new CommentsDTO
                    {
                        Id = c.Id,
                        CommentId = c.CommentId,
                        CreationDate = c.CreationDate,
                        Text = c.Text,
                        TopicId = c.TopicId,
                        UserId = c.UserId,
                        TimeAgo = TimeAgo.GetTimeAgo(c.CreationDate)
                    };

                    comments.Add(coment);
                }

                //get the last commnet ID
                int lastPostId = comments.Max(x => x.CommentId);
                var lastComment = comments.FirstOrDefault(x => x.CommentId == lastPostId) ;

                //get the user that post the last comment on the topic
                var lastUserComment = await _userRepository.GetById(lastComment.UserId);

                var lasCommentTimePast = lastComment.TimeAgo;

                var lastUserPost = new UserDTO
                {
                    Id = lastUserComment.Id,
                    Name = lastUserComment.Name,
                    Email = lastUserComment.Email,
                    IdentityId = lastUserComment.IdentityId,
                    LastActivity = lastUserComment.LastActivity,
                    UserTypeId = lastUserComment.UserTypeId,
                    CreationDate = lastUserComment.CreationDate,
                    Avatar = lastUserComment.Avatar
                };

                topic.LastCommentTimeAgo = lasCommentTimePast;
                topic.UserLastPost = lastUserPost;
                topic.User = user;
                topic.Coments = comments;

                topicList.Add(topic);
            }

            return topicList;
        }
    }
}
