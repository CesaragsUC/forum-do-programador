using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface IAreaQuery
    {
        Task<AreaDTO> GetById(Guid id);
        Task<IEnumerable<AreaDTO>> GetAll();
    }
}
