using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries
{
    public class UserFriendQuery : IUserFriendQuery
    {
        private readonly IUserFriendRepository _userFriendRepository;
        private readonly IUserRepository _userRepository;
        public UserFriendQuery(IUserFriendRepository userFriendRepository,
            IUserRepository userRepository)
        {
            _userFriendRepository = userFriendRepository;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserFriendDTO>> GetAll()
        {
            var userFriends = await _userFriendRepository.GetAll();

            var userFriendsListDTO = new List<UserFriendDTO>();


            foreach (var f in userFriends)
            {
                var user = await _userRepository.GetById(f.UserId);
                var userFriend = await _userRepository.GetById(f.FriendId);

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

                var userFriendDTO = new UserDTO
                {
                    Id = userFriend.Id,
                    Name = userFriend.Name,
                    Email = userFriend.Email,
                    IdentityId = userFriend.IdentityId,
                    LastActivity = userFriend.LastActivity,
                    UserTypeId = userFriend.UserTypeId,
                    CreationDate = userFriend.CreationDate,
                    Avatar = userFriend.Avatar
                };

                var friend = new UserFriendDTO
                {
                    FriendId = f.FriendId,
                    UserId = userDTO.Id,
                    CreationDate = f.CreationDate,
                    User = userDTO,
                    Friend = userFriendDTO
                };

                userFriendsListDTO.Add(friend);
            }

            return userFriendsListDTO;
        }

        public async Task<IEnumerable<UserFriendDTO>> GetByUserId(Guid friendId)
        {
            var userFriends = await _userFriendRepository.GetByUserId(friendId);

            var userFriendsListDTO = new List<UserFriendDTO>();

            foreach (var f in userFriends)
            {
                //current profile user
                var user = await _userRepository.GetById(friendId);

                //his friend
                var userFriend = await _userRepository.GetById(f.User.Id);

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

                var userFriendDTO = new UserDTO
                {
                    Id = userFriend.Id,
                    Name = userFriend.Name,
                    Email = userFriend.Email,
                    IdentityId = userFriend.IdentityId,
                    LastActivity = userFriend.LastActivity,
                    UserTypeId = userFriend.UserTypeId,
                    CreationDate = userFriend.CreationDate,
                    Avatar = userFriend.Avatar
                };

                var friend = new UserFriendDTO
                {
                    FriendId = f.FriendId,
                    UserId = friendId,
                    CreationDate = f.CreationDate,
                    User = userDTO,
                    Friend = userFriendDTO
                };

                userFriendsListDTO.Add(friend);
            }

            return userFriendsListDTO;
        }
    }
}
