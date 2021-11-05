using Forum.Core.Data;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface ISectionRepository : IRepository<Section>
    {
        Task<Section> GetById(Guid id);
        Task<IEnumerable<Section>> GetAll();
        void Add(Section section);
        void Update(Section section);
        void Delete(Section section);
    }
}
