using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface IAreaRepository : IRepository<Area>
    {
        Task<Area> GetById(Guid id);
        Task<IEnumerable<Area>> GetAll();
        void Add(Area area);
        void Update(Area area);
        void Delete(Area area);
    }
}
