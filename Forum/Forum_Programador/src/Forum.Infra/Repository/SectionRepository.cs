using Forum.Core;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infra.Repository
{
    public class SectionRepository : ISectionRepository
    {

        private readonly ForumContext _context;
        public SectionRepository(ForumContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Section section)
        {
            _context.Add(section);
        }

        public void Delete(Section section)
        {
            _context.Remove(section);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<Section>> GetAll()
        {
            var section = await (from sc in _context.Sections
                                 join area in _context.Areas on sc.AreaId equals area.Id
                                 select sc).AsNoTracking().ToListAsync();


            return section;

        }

        public async Task<Section> GetById(Guid id)
        {
            return await _context.Sections.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Section section)
        {
            _context.Update(section);
        }
    }
}
