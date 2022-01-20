using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Application.Queries.Helpers;
using Forum.Domain.Entities;

namespace Forum.Application.Queries
{
    public class PrivateMessagesQuery : IPrivateMessagesQuery
    {

        private readonly IPrivateMessageRepository _privateMessageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMessageCommentRepository _messageCommentRepository;

        public PrivateMessagesQuery(IPrivateMessageRepository privateMessageRepository,
            IUserRepository userRepository, IMessageCommentRepository messageCommentRepository)
        {
            _privateMessageRepository = privateMessageRepository;
            _userRepository = userRepository;
            _messageCommentRepository = messageCommentRepository;
        }


        public async Task<IEnumerable<PrivateMessagesDTO>> GetAll()
        {
            var privatemessages = await _privateMessageRepository.GetAll();

            var privateMessagesDTO = new List<PrivateMessagesDTO>();

            foreach (var pm in privatemessages)
            {
                var msg = new PrivateMessagesDTO
                {
                    Id = pm.Id,
                    CreationDate =pm.CreationDate,
                    IsSeen = pm.IsSeen,
                    RecipientId = pm.RecipientId,
                    SenderId = pm.SenderId,
                    Subject = pm.Subject,
                    IsReplied = pm.IsReplied

                };

                var senderDTO = new UserDTO
                {
                    Id = pm.Sender.Id,
                    Avatar = pm.Sender.Avatar,
                    CreationDate = pm.Sender.CreationDate,
                    Email = pm.Sender.Email,
                    IdentityId = pm.Sender.IdentityId,
                    LastActivity = pm.Sender.LastActivity,
                    Name = pm.Sender.Name,
                    UserTypeId = pm.Sender.UserTypeId
                };

                var recipientDTO = new UserDTO
                {
                    Id = pm.Recipient.Id,
                    Avatar = pm.Recipient.Avatar,
                    CreationDate = pm.Recipient.CreationDate,
                    Email = pm.Recipient.Email,
                    IdentityId = pm.Recipient.IdentityId,
                    LastActivity = pm.Recipient.LastActivity,
                    Name = pm.Recipient.Name,
                    UserTypeId = pm.Recipient.UserTypeId
                };

                msg.Sender = senderDTO;
                msg.Recipient = recipientDTO;

                privateMessagesDTO.Add(msg);
            }

            return privateMessagesDTO;
        }

        //public async Task<IEnumerable<MessageCommentDTO>> GetComments(Guid messageId)
        //{
        //    var comments = await _privateMessageRepository.GetById(id);
        //}

        public async Task<PrivateMessagesDTO> GetById(Guid id)
        {
            var privatemessage = await _privateMessageRepository.GetById(id);

            var privateMessagesDTO = new PrivateMessagesDTO
            {
                Id = privatemessage.Id,
                CreationDate = privatemessage.CreationDate,
                IsSeen = privatemessage.IsSeen,
                RecipientId = privatemessage.RecipientId,
                SenderId = privatemessage.SenderId,
                Subject = privatemessage.Subject,
                IsReplied = privatemessage.IsReplied
            };

            var senderDTO = new UserDTO
            {
                Id = privatemessage.Sender.Id,
                Avatar = privatemessage.Sender.Avatar,
                CreationDate = privatemessage.Sender.CreationDate,
                Email = privatemessage.Sender.Email,
                IdentityId = privatemessage.Sender.IdentityId,
                LastActivity = privatemessage.Sender.LastActivity,
                Name = privatemessage.Sender.Name,
                UserTypeId = privatemessage.Sender.UserTypeId
            };

            var recipientDTO = new UserDTO
            {
                Id = privatemessage.Recipient.Id,
                Avatar = privatemessage.Recipient.Avatar,
                CreationDate = privatemessage.Recipient.CreationDate,
                Email = privatemessage.Recipient.Email,
                IdentityId = privatemessage.Recipient.IdentityId,
                LastActivity = privatemessage.Recipient.LastActivity,
                Name = privatemessage.Recipient.Name,
                UserTypeId = privatemessage.Recipient.UserTypeId
            };

            privateMessagesDTO.Recipient = recipientDTO;
            privateMessagesDTO.Sender = senderDTO;

            return privateMessagesDTO;
        }

        public async Task<IEnumerable<PrivateMessagesDTO>> GetByRecipientId(Guid userId)
        {
            var messagesReceived = await _privateMessageRepository.GetByRecipientId(userId);

            var listMessagesDTO = new List<PrivateMessagesDTO>();

            var commentsDTO = new List<MessageCommentDTO>();

           

            IEnumerable<PrivateMessages> myRepliedMessages;

            if (messagesReceived.Any())
            {

                //all messages send to me
                foreach (var message in messagesReceived)
                {

                    var privateMessagesDTO = new PrivateMessagesDTO
                    {
                        Id = message.Id,
                        CreationDate = message.CreationDate,
                        IsSeen = message.IsSeen,
                        RecipientId = message.RecipientId,
                        SenderId = message.SenderId,
                        Subject = message.Subject,
                        TimeAgo = TimeAgo.GetTimeAgo(message.CreationDate)

                    };

                    var senderDTO = new UserDTO
                    {
                        Id = message.Sender.Id,
                        Avatar = message.Sender.Avatar,
                        CreationDate = message.Sender.CreationDate,
                        Email = message.Sender.Email,
                        IdentityId = message.Sender.IdentityId,
                        LastActivity = message.Sender.LastActivity,
                        Name = message.Sender.Name,
                        UserTypeId = message.Sender.UserTypeId
                    };

                    var recipientDTO = new UserDTO
                    {
                        Id = message.Recipient.Id,
                        Avatar = message.Recipient.Avatar,
                        CreationDate = message.Recipient.CreationDate,
                        Email = message.Recipient.Email,
                        IdentityId = message.Recipient.IdentityId,
                        LastActivity = message.Recipient.LastActivity,
                        Name = message.Recipient.Name,
                        UserTypeId = message.Recipient.UserTypeId
                    };

                    foreach (var comment in message.MessageComments.OrderBy(c=>c.CreationDate))
                    {

                        var user = await _userRepository.GetById(comment.UserId);

                        var userDTO = new UserDTO
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Email = user.Email,
                            IdentityId = user.IdentityId,
                            LastActivity = user.LastActivity,
                            UserTypeId = user.UserTypeId,
                            CreationDate = user.CreationDate,
                            Avatar = user.Avatar
                        };

                        var cm = new MessageCommentDTO
                        {
                            Id = comment.Id,
                            CreationDate = comment.CreationDate,
                            IsSeen = comment.IsSeen,
                            PrivateMessageId = comment.PrivateMessageId,
                            Text = comment.Text,
                            TimeAgo = TimeAgo.GetTimeAgo(message.CreationDate),
                            UserId = comment.UserId,
                            User = userDTO,
                            PrivateMessages = privateMessagesDTO


                        };
                        commentsDTO.Add(cm);

                    }


                    privateMessagesDTO.Recipient = recipientDTO;
                    privateMessagesDTO.Sender = senderDTO;
                    privateMessagesDTO.Comments = commentsDTO;
                    privateMessagesDTO.LastMessageDate = commentsDTO.Max(d => d.CreationDate);

                    var lastUserComent = commentsDTO.OrderBy(c => c.UserId)
                        .OrderByDescending(x => x.CreationDate)
                        .Select(x => x.User.Name)
                        .FirstOrDefault();
                    privateMessagesDTO.LastUserComment = lastUserComent;

                   listMessagesDTO.Add(privateMessagesDTO);
                }


                //all my messages replied, should appears on my box too
                myRepliedMessages = await _privateMessageRepository.GetBySenderyId(userId);

                var totalComments = myRepliedMessages.Where(x => x.IsReplied);

                if (totalComments.Any())
                {
                    foreach (var rpm in myRepliedMessages)
                    {

                        var privateMessages = new PrivateMessagesDTO
                        {
                            Id = rpm.Id,
                            CreationDate = rpm.CreationDate,
                            IsSeen = rpm.IsSeen,
                            RecipientId = rpm.RecipientId,
                            SenderId = rpm.SenderId,
                            Subject = rpm.Subject,
                            TimeAgo = TimeAgo.GetTimeAgo(rpm.CreationDate),
                            IsReplied = rpm.IsReplied

                        };

                        var sender = new UserDTO
                        {
                            Id = rpm.Sender.Id,
                            Avatar = rpm.Sender.Avatar,
                            CreationDate = rpm.Sender.CreationDate,
                            Email = rpm.Sender.Email,
                            IdentityId = rpm.Sender.IdentityId,
                            LastActivity = rpm.Sender.LastActivity,
                            Name = rpm.Sender.Name,
                            UserTypeId = rpm.Sender.UserTypeId
                        };

                        var recipient = new UserDTO
                        {
                            Id = rpm.Recipient.Id,
                            Avatar = rpm.Recipient.Avatar,
                            CreationDate = rpm.Recipient.CreationDate,
                            Email = rpm.Recipient.Email,
                            IdentityId = rpm.Recipient.IdentityId,
                            LastActivity = rpm.Recipient.LastActivity,
                            Name = rpm.Recipient.Name,
                            UserTypeId = rpm.Recipient.UserTypeId
                        };

                        foreach (var comment in rpm.MessageComments.OrderBy(c => c.CreationDate))
                        {

                            var user = await _userRepository.GetById(comment.UserId);

                            var userDTO = new UserDTO
                            {
                                Id = user.Id,
                                Name = user.Name,
                                Email = user.Email,
                                IdentityId = user.IdentityId,
                                LastActivity = user.LastActivity,
                                UserTypeId = user.UserTypeId,
                                CreationDate = user.CreationDate,
                                Avatar = user.Avatar
                            };

                            var cm = new MessageCommentDTO
                            {
                                Id = comment.Id,
                                CreationDate = comment.CreationDate,
                                IsSeen = comment.IsSeen,
                                PrivateMessageId = comment.PrivateMessageId,
                                Text = comment.Text,
                                TimeAgo = TimeAgo.GetTimeAgo(rpm.CreationDate),
                                UserId = comment.UserId,
                                User = userDTO,
                                PrivateMessages = privateMessages


                            };
                            commentsDTO.Add(cm);

                        }


                        privateMessages.Recipient = recipient;
                        privateMessages.Sender = sender;
                        privateMessages.Comments = commentsDTO;

                        privateMessages.LastMessageDate = commentsDTO.Max(d => d.CreationDate);

                        var lastUserComent = commentsDTO.OrderBy(c => c.UserId)
                            .OrderByDescending(x => x.CreationDate)
                            .Select(x => x.User.Name)
                            .FirstOrDefault();
                        privateMessages.LastUserComment = lastUserComent;

                        listMessagesDTO.Add(privateMessages);
                    }
                }

            }
            else
            {
                myRepliedMessages = await _privateMessageRepository.GetBySenderyId(userId);

                var totalComments = myRepliedMessages.Where(x => x.IsReplied);

                if (totalComments.Any())
                {
                    foreach (var message in myRepliedMessages)
                    {

                        var privateMessagesDTO = new PrivateMessagesDTO
                        {
                            Id = message.Id,
                            CreationDate = message.CreationDate,
                            IsSeen = message.IsSeen,
                            RecipientId = message.RecipientId,
                            SenderId = message.SenderId,
                            Subject = message.Subject,
                            TimeAgo = TimeAgo.GetTimeAgo(message.CreationDate),
                            IsReplied = message.IsReplied

                        };

                        var senderDTO = new UserDTO
                        {
                            Id = message.Sender.Id,
                            Avatar = message.Sender.Avatar,
                            CreationDate = message.Sender.CreationDate,
                            Email = message.Sender.Email,
                            IdentityId = message.Sender.IdentityId,
                            LastActivity = message.Sender.LastActivity,
                            Name = message.Sender.Name,
                            UserTypeId = message.Sender.UserTypeId
                        };

                        var recipientDTO = new UserDTO
                        {
                            Id = message.Recipient.Id,
                            Avatar = message.Recipient.Avatar,
                            CreationDate = message.Recipient.CreationDate,
                            Email = message.Recipient.Email,
                            IdentityId = message.Recipient.IdentityId,
                            LastActivity = message.Recipient.LastActivity,
                            Name = message.Recipient.Name,
                            UserTypeId = message.Recipient.UserTypeId
                        };

                        foreach (var comment in message.MessageComments)
                        {

                            var user = await _userRepository.GetById(comment.UserId);

                            var userDTO = new UserDTO
                            {
                                Id = user.Id,
                                Name = user.Name,
                                Email = user.Email,
                                IdentityId = user.IdentityId,
                                LastActivity = user.LastActivity,
                                UserTypeId = user.UserTypeId,
                                CreationDate = user.CreationDate,
                                Avatar = user.Avatar
                            };

                            var cm = new MessageCommentDTO
                            {
                                Id = comment.Id,
                                CreationDate = comment.CreationDate,
                                IsSeen = comment.IsSeen,
                                PrivateMessageId = comment.PrivateMessageId,
                                Text = comment.Text,
                                TimeAgo = TimeAgo.GetTimeAgo(message.CreationDate),
                                UserId = comment.UserId,
                                User = userDTO,
                                PrivateMessages = privateMessagesDTO


                            };
                            commentsDTO.Add(cm);

                        }


                        privateMessagesDTO.Recipient = recipientDTO;
                        privateMessagesDTO.Sender = senderDTO;
                        privateMessagesDTO.Comments = commentsDTO;

                        privateMessagesDTO.LastMessageDate = commentsDTO.Max(d => d.CreationDate);

                        var lastUserComent = commentsDTO.OrderBy(c => c.UserId)
                            .OrderByDescending(x => x.CreationDate)
                            .Select(x => x.User.Name)
                            .FirstOrDefault();
                        privateMessagesDTO.LastUserComment = lastUserComent;

                        listMessagesDTO.Add(privateMessagesDTO);
                    }
                }

            }

            return listMessagesDTO;
        }

        public async Task<IEnumerable<PrivateMessagesDTO>> GetBySenderyId(Guid senderId)
        {
            var privatemessage = await _privateMessageRepository.GetByRecipientId(senderId);

            var listMessagesDTO = new List<PrivateMessagesDTO>();
            var commentsDTO = new List<MessageCommentDTO>();

            foreach (var message in privatemessage)
            {
                var privateMessagesDTO = new PrivateMessagesDTO
                {
                    Id = message.Id,
                    CreationDate = message.CreationDate,
                    IsSeen = message.IsSeen,
                    RecipientId = message.RecipientId,
                    SenderId = message.SenderId,
                    Subject = message.Subject

                };

                var senderDTO = new UserDTO
                {
                    Id = message.Sender.Id,
                    Avatar = message.Sender.Avatar,
                    CreationDate = message.Sender.CreationDate,
                    Email = message.Sender.Email,
                    IdentityId = message.Sender.IdentityId,
                    LastActivity = message.Sender.LastActivity,
                    Name = message.Sender.Name,
                    UserTypeId = message.Sender.UserTypeId
                };

                var recipientDTO = new UserDTO
                {
                    Id = message.Recipient.Id,
                    Avatar = message.Recipient.Avatar,
                    CreationDate = message.Recipient.CreationDate,
                    Email = message.Recipient.Email,
                    IdentityId = message.Recipient.IdentityId,
                    LastActivity = message.Recipient.LastActivity,
                    Name = message.Recipient.Name,
                    UserTypeId = message.Recipient.UserTypeId
                };

                var comments = await _messageCommentRepository.GetByMessageId(message.Id);

                foreach (var comment in comments)
                {

                    var user = await _userRepository.GetById(comment.UserId);

                    var userDTO = new UserDTO
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        IdentityId = user.IdentityId,
                        LastActivity = user.LastActivity,
                        UserTypeId = user.UserTypeId,
                        CreationDate = user.CreationDate,
                        Avatar = user.Avatar
                    };

                    var cm = new MessageCommentDTO
                    {
                        Id = comment.Id,
                        CreationDate = comment.CreationDate,
                        IsSeen = comment.IsSeen,
                        PrivateMessageId = comment.PrivateMessageId,
                        Text = comment.Text,
                        TimeAgo = TimeAgo.GetTimeAgo(message.CreationDate),
                        UserId = comment.UserId,
                        User = userDTO,
                        PrivateMessages = privateMessagesDTO


                    };
                    commentsDTO.Add(cm);

                }

                privateMessagesDTO.Recipient = recipientDTO;
                privateMessagesDTO.Sender = senderDTO;
                privateMessagesDTO.Comments = commentsDTO;

                listMessagesDTO.Add(privateMessagesDTO);
            }

            return listMessagesDTO;
        }

        public async Task<IEnumerable<PrivateMessagesDTO>> GetBySubject(string subject)
        {
            var privatemessage = await _privateMessageRepository.GetBySubject(subject);

            var listMessagesDTO = new List<PrivateMessagesDTO>();
            var commentsDTO = new List<MessageCommentDTO>();

            foreach (var message in privatemessage)
            {
                var privateMessagesDTO = new PrivateMessagesDTO
                {
                    Id = message.Id,
                    CreationDate = message.CreationDate,
                    IsSeen = message.IsSeen,
                    RecipientId = message.RecipientId,
                    SenderId = message.SenderId,
                    Subject = message.Subject,
                    IsReplied = message.IsReplied

                };

                var senderDTO = new UserDTO
                {
                    Id = message.Sender.Id,
                    Avatar = message.Sender.Avatar,
                    CreationDate = message.Sender.CreationDate,
                    Email = message.Sender.Email,
                    IdentityId = message.Sender.IdentityId,
                    LastActivity = message.Sender.LastActivity,
                    Name = message.Sender.Name,
                    UserTypeId = message.Sender.UserTypeId
                };

                var recipientDTO = new UserDTO
                {
                    Id = message.Recipient.Id,
                    Avatar = message.Recipient.Avatar,
                    CreationDate = message.Recipient.CreationDate,
                    Email = message.Recipient.Email,
                    IdentityId = message.Recipient.IdentityId,
                    LastActivity = message.Recipient.LastActivity,
                    Name = message.Recipient.Name,
                    UserTypeId = message.Recipient.UserTypeId
                };

                var comments = await _messageCommentRepository.GetByMessageId(message.Id);

                foreach (var comment in comments)
                {

                    var user = await _userRepository.GetById(comment.UserId);

                    var userDTO = new UserDTO
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        IdentityId = user.IdentityId,
                        LastActivity = user.LastActivity,
                        UserTypeId = user.UserTypeId,
                        CreationDate = user.CreationDate,
                        Avatar = user.Avatar
                    };

                    var cm = new MessageCommentDTO
                    {
                        Id = comment.Id,
                        CreationDate = comment.CreationDate,
                        IsSeen = comment.IsSeen,
                        PrivateMessageId = comment.PrivateMessageId,
                        Text = comment.Text,
                        TimeAgo = TimeAgo.GetTimeAgo(message.CreationDate),
                        UserId = comment.UserId,
                        User = userDTO,
                        PrivateMessages = privateMessagesDTO


                    };
                    commentsDTO.Add(cm);

                }

                privateMessagesDTO.Recipient = recipientDTO;
                privateMessagesDTO.Sender = senderDTO;
                privateMessagesDTO.Comments = commentsDTO;

                listMessagesDTO.Add(privateMessagesDTO);
            }

            return listMessagesDTO;
        }

    }
}
