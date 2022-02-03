using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;

namespace Forum.Application.Queries
{
    public class ReportUserQuery : IReportUserQuery
    {
        private readonly IReportUserRepository _reportUserRepository;
        private readonly IUserRepository _userRepository;
        public ReportUserQuery(IReportUserRepository reportUserRepository, IUserRepository userRepository)
        {
            _reportUserRepository = reportUserRepository;
            _userRepository = userRepository;
        }
        public async Task<ReportUserDTO> GetById(Guid id)
        {
            var report = await _reportUserRepository.GetById(id);

            var user = await _userRepository.GetById(report.UserId);

            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IdentityId = user.IdentityId,
                LastActivity = user.LastActivity,
                UserTypeId = user.UserTypeId,
                CreationDate = user.CreationDate,
                Avatar = user.Avatar,
                IsBanned = user.IsBanned
            };

            var reportDTO = new ReportUserDTO
            {
                UserId = report.UserId,
                Reason = report.Reason,
                CreationDate = report.CreationDate,
                UserSendReportId = report.UserSendReportId,
                IsBanned = user.IsBanned,
                Name = user.Name
            };

            return reportDTO;
        }

        public async Task<IEnumerable<ReportUserDTO>> GetByUserId(Guid userId)
        {
            var reports = await _reportUserRepository.GetByUserId(userId);

            var reportList = new List<ReportUserDTO>();

            foreach (var report in reports)
            {
                var user = await _userRepository.GetById(report.UserId);

                var userDTO = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    IdentityId = user.IdentityId,
                    LastActivity = user.LastActivity,
                    UserTypeId = user.UserTypeId,
                    CreationDate = user.CreationDate,
                    Avatar = user.Avatar,
                    IsBanned = user.IsBanned
                };


                var reportDTO = new ReportUserDTO
                {
                    UserId = report.UserId,
                    Reason = report.Reason,
                    CreationDate = report.CreationDate,
                    UserSendReportId = report.UserSendReportId,
                    IsBanned = user.IsBanned,
                    Name = user.Name
                };
                reportList.Add(reportDTO);
            }


            return reportList;
        }

        public async Task<IEnumerable<ReportUserDTO>> GetAll()
        {
            var reports = await _reportUserRepository.GetAll();

            var reportList = new List<ReportUserDTO>();

            foreach (var report in reports)
            {
                var user = await _userRepository.GetById(report.UserId);

                var userDTO = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    IdentityId = user.IdentityId,
                    LastActivity = user.LastActivity,
                    UserTypeId = user.UserTypeId,
                    CreationDate = user.CreationDate,
                    Avatar = user.Avatar,
                    IsBanned = user.IsBanned
                };

                var reportDTO = new ReportUserDTO
                {
                    UserId = report.UserId,
                    Reason = report.Reason,
                    CreationDate = report.CreationDate,
                    UserSendReportId = report.UserSendReportId,
                    IsBanned = user.IsBanned,
                    Name = user.Name
                };
                reportList.Add(reportDTO);
            }


            return reportList;
        }
    }
}
