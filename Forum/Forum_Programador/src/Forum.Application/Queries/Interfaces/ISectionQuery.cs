using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface ISectionQuery
    {
        Task<SectionDTO> GetById(Guid id);
        Task<IEnumerable<SectionDTO>> GetAll();
    }
}
