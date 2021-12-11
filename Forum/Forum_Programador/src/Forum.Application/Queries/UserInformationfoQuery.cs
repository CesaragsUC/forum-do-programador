using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries
{
    public class UserInformationfoQuery : IUserInformationfoQuery
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IUserRepository _userRepository;
        public UserInformationfoQuery(IUserInformationRepository userInformationRepository,
            IUserRepository userRepository)
        {
            _userInformationRepository = userInformationRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserInformationDTO>> GetAll()
        {
            var userInfoList = await _userInformationRepository.GetAll();

            var userInfoListDTO = new List<UserInformationDTO>();

            foreach (var info in userInfoList)
            {
                var user = await _userRepository.GetById(info.UserId);

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

                var userInfoDTO = new UserInformationDTO
                {
                    Id = info.Id,
                    UserId = info.UserId,
                    Adress = info.Adress,
                    Email = info.User.Email,
                    FaceBook = info.FaceBook,
                    FullName = info.FullName,
                    GitHub = info.GitHub,
                    Instagran = info.Instagran,
                    Occupation = info.Occupation,
                    Twitter = info.Twitter,
                    User = userDTO,
                    WebSite = info.WebSite
                };

                userInfoListDTO.Add(userInfoDTO);
            }

            return userInfoListDTO;
        }

        public async Task<UserInformationDTO> GetByUserId(Guid userId)
        {
            var userInfo = await _userInformationRepository.GetById(userId);
            var user = await _userRepository.GetById(userId);

            if (userInfo == null) return null;

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

            var userInfoDTO = new UserInformationDTO
            {
                Id = userInfo.Id,
                UserId = userInfo.UserId,
                Adress = userInfo.Adress,
                Email = userInfo.User.Email,
                FaceBook = userInfo.FaceBook,
                FullName = userInfo.FullName,
                GitHub = userInfo.GitHub,
                Instagran = userInfo.Instagran,
                Occupation = userInfo.Occupation,
                Twitter = userInfo.Twitter,
                User = userDTO,
                WebSite = userInfo.WebSite
            };

            return userInfoDTO;
        }
    }
}
