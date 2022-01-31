using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Core.Data;

namespace Forum.Domain.Interfaces
{
    public interface IReportUserRepository : IRepository<ReportUsers>
    {
        Task<ReportUsers> GetById(Guid id);
        Task<IEnumerable<ReportUsers>> GetByUserId(Guid userId);
        Task<IEnumerable<ReportUsers>> GetAll();
        void Add(ReportUsers reportUsers);
        void Update(ReportUsers reportUsers);
        void Delete(ReportUsers reportUsers);
    }
}
