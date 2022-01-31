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
        public ReportUserQuery(IReportUserRepository reportUserRepository)
        {
            _reportUserRepository = reportUserRepository;
        }
        public async Task<ReportUserDTO> GetById(Guid id)
        {
            var report = await _reportUserRepository.GetById(id);
            var reportDTO = new ReportUserDTO
            {
                UserId = report.UserId,
                Reason = report.Reason,
                CreationDate = report.CreationDate,
                UserSendReportId = report.UserSendReportId
            };

            return reportDTO;
        }

        public async Task<IEnumerable<ReportUserDTO>> GetByUserId(Guid userId)
        {
            var reports = await _reportUserRepository.GetByUserId(userId);

            var reportList = new List<ReportUserDTO>();

            foreach (var report in reports)
            {
                var reportDTO = new ReportUserDTO
                {
                    UserId = report.UserId,
                    Reason = report.Reason,
                    CreationDate = report.CreationDate,
                    UserSendReportId = report.UserSendReportId
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
                var reportDTO = new ReportUserDTO
                {
                    UserId = report.UserId,
                    Reason = report.Reason,
                    CreationDate = report.CreationDate,
                    UserSendReportId = report.UserSendReportId
                };
                reportList.Add(reportDTO);
            }


            return reportList;
        }
    }
}
