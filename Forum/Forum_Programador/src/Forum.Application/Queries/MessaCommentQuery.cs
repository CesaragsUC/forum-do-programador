using Forum.Application.DTO;
using Forum.Application.Queries.Helpers;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries
{
    public class MessaCommentQuery : IMessaCommentsQuery
    {

        private readonly IMessageCommentRepository _messageCommentRepository;
        private readonly IUserRepository _userRepository;

        public MessaCommentQuery(IMessageCommentRepository messageCommentRepository, IUserRepository userRepository)
        {
            _messageCommentRepository = messageCommentRepository;
            _userRepository = userRepository;
        }


        public async Task<IEnumerable<MessageCommentDTO>> GetByMessageId(Guid messageId)
        {
            var comments = await _messageCommentRepository.GetByMessageId(messageId);

            var commentsDTO = new List<MessageCommentDTO>();

            foreach (var comment in comments)
            {

                var userSender = await _userRepository.GetById(comment.UserId);

                var senderDTO = new UserDTO
                {
                    Id = userSender.Id,
                    Avatar = userSender.Avatar,
                    CreationDate = userSender.CreationDate,
                    Email = userSender.Email,
                    IdentityId = userSender.IdentityId,
                    LastActivity = userSender.LastActivity,
                    Name = userSender.Name,
                    UserTypeId = userSender.UserTypeId
                };

                var cm = new MessageCommentDTO
                {
                    UserId = comment.UserId,
                    CreationDate = comment.CreationDate,
                    IsSeen = comment.IsSeen,
                    Text = comment.Text,
                    TimeAgo = TimeAgo.GetTimeAgo(comment.CreationDate),
                    User = senderDTO

                };

                commentsDTO.Add(cm);
            }

            return commentsDTO;
        }

        public async Task<IEnumerable<MessageCommentDTO>> GetByUserId(Guid userId)
        {
            var comments = await _messageCommentRepository.GetByUserId(userId);

            var commentsDTO = new List<MessageCommentDTO>();

            foreach (var comment in comments)
            {

                var userSender = await _userRepository.GetById(comment.UserId);

                var senderDTO = new UserDTO
                {
                    Id = userSender.Id,
                    Avatar = userSender.Avatar,
                    CreationDate = userSender.CreationDate,
                    Email = userSender.Email,
                    IdentityId = userSender.IdentityId,
                    LastActivity = userSender.LastActivity,
                    Name = userSender.Name,
                    UserTypeId = userSender.UserTypeId
                };

                var cm = new MessageCommentDTO
                {
                    UserId = comment.UserId,
                    CreationDate = comment.CreationDate,
                    IsSeen = comment.IsSeen,
                    Text = comment.Text,
                    TimeAgo = TimeAgo.GetTimeAgo(comment.CreationDate),
                    User = senderDTO

                };

                commentsDTO.Add(cm);
            }

            return commentsDTO;
        }

        public async Task<IEnumerable<MessageCommentDTO>> GetAll()
        {
            var comments = await _messageCommentRepository.GetAll();

            var commentsDTO = new List<MessageCommentDTO>();

            foreach (var comment in comments)
            {

                var userSender = await _userRepository.GetById(comment.UserId);

                var senderDTO = new UserDTO
                {
                    Id = userSender.Id,
                    Avatar = userSender.Avatar,
                    CreationDate = userSender.CreationDate,
                    Email = userSender.Email,
                    IdentityId = userSender.IdentityId,
                    LastActivity = userSender.LastActivity,
                    Name = userSender.Name,
                    UserTypeId = userSender.UserTypeId
                };

                var cm = new MessageCommentDTO
                {
                    UserId = comment.UserId,
                    CreationDate = comment.CreationDate,
                    IsSeen = comment.IsSeen,
                    Text = comment.Text,
                    TimeAgo = TimeAgo.GetTimeAgo(comment.CreationDate),
                    User = senderDTO

                };

                commentsDTO.Add(cm);
            }

            return commentsDTO;
        }
    }
}
