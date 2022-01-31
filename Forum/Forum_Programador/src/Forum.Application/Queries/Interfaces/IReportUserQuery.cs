using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.DTO;

namespace Forum.Application.Queries.Interfaces
{
    public interface IReportUserQuery
    {
        Task<ReportUserDTO> GetById(Guid id);
        Task<IEnumerable<ReportUserDTO>> GetByUserId(Guid userId);
        Task<IEnumerable<ReportUserDTO>> GetAll();
    }
}
