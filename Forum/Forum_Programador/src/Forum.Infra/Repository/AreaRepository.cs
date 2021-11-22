using Forum.Core;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Infra.Repository
{
    public class AreaRepository : IAreaRepository
    {

        private readonly ForumContext _context;
        public AreaRepository(ForumContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Area section)
        {
            _context.Add(section);
        }

        public void Delete(Area section)
        {
            _context.Remove(section);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<Area>> GetAll()
        {

            return await _context.Areas.AsNoTracking()
                .Include(s => s.Sections).OrderBy(s => s.Name).ToListAsync();
        }

        public async Task<Area> GetById(Guid id)
        {
            return await _context.Areas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Area section)
        {
            _context.Update(section);
        }
    }
}
