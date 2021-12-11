using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries
{
    public class UserQuery : IUserQuery
    {

        private readonly IUserRepository _userRepository;
        public UserQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await _userRepository.GetAll();
            if (users == null) return null;

            var userList = new List<UserDTO>();

            foreach (var item in users)
            {
                var user = new UserDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    IdentityId = item.IdentityId,
                    LastActivity = item.LastActivity,
                    UserTypeId = item.UserTypeId,
                    CreationDate = item.CreationDate,
                    Avatar = item.Avatar
                };
                userList.Add(user);
            }
            return userList;

        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) return null;

            var userModel = new UserDTO
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

            return userModel;
        }

        public async Task<UserDTO> GetByIdentityId(Guid identityId)
        {
            var user = await _userRepository.GetByIdentityId(identityId);
            if (user == null) return null;

            var userModel = new UserDTO
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

            return userModel;
        }

        public async Task<UserDTO> GetByNameAndEmail(string name, string email)
        {
            var user = await _userRepository.GetByNameAndEmail(name, email);
            var userModel = new UserDTO
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
            return userModel;
        }
    }
}
