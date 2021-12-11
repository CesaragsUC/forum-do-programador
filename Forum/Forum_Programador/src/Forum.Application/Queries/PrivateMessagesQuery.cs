using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries
{
    public class PrivateMessagesQuery : IPrivateMessagesQuery
    {

        private readonly IPrivateMessageRepository _privateMessageRepository;
        private readonly IUserRepository _userRepository;

        public PrivateMessagesQuery(IPrivateMessageRepository privateMessageRepository,
            IUserRepository userRepository)
        {
            _privateMessageRepository = privateMessageRepository;
            _userRepository = userRepository;
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
                    Text = pm.Text

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
                Text = privatemessage.Text

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
            var privatemessage = await _privateMessageRepository.GetByRecipientId(userId);
           
            var listMessagesDTO = new List<PrivateMessagesDTO>();

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
                    Text = message.Text

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

                privateMessagesDTO.Recipient = recipientDTO;
                privateMessagesDTO.Sender = senderDTO;

                listMessagesDTO.Add(privateMessagesDTO);
            }

            return listMessagesDTO;
        }

        public async Task<IEnumerable<PrivateMessagesDTO>> GetBySenderyId(Guid senderId)
        {
            var privatemessage = await _privateMessageRepository.GetByRecipientId(senderId);

            var listMessagesDTO = new List<PrivateMessagesDTO>();

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
                    Text = message.Text

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

                privateMessagesDTO.Recipient = recipientDTO;
                privateMessagesDTO.Sender = senderDTO;

                listMessagesDTO.Add(privateMessagesDTO);
            }

            return listMessagesDTO;
        }

        public async Task<IEnumerable<PrivateMessagesDTO>> GetBySubject(string subject)
        {
            var privatemessage = await _privateMessageRepository.GetBySubject(subject);

            var listMessagesDTO = new List<PrivateMessagesDTO>();

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
                    Text = message.Text

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

                privateMessagesDTO.Recipient = recipientDTO;
                privateMessagesDTO.Sender = senderDTO;

                listMessagesDTO.Add(privateMessagesDTO);
            }

            return listMessagesDTO;
        }

    }
}
