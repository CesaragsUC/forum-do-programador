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
    public class ReportUserRepository : IReportUserRepository
    {
        private readonly ForumContext _context;

        public ReportUserRepository(ForumContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task<ReportUsers> GetById(Guid id)
        {
            return _context.ReportUsers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ReportUsers>> GetByUserId(Guid userId)
        {
            return await _context.ReportUsers.Where(x => x.UserId == userId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ReportUsers>> GetAll()
        {
            return await _context.ReportUsers.AsNoTracking().ToListAsync();
        }

        public void Add(ReportUsers reportUsers)
        {
            _context.ReportUsers.Add(reportUsers);
        }

        public void Update(ReportUsers reportUsers)
        {
            _context.ReportUsers.Update(reportUsers);
        }

        public void Delete(ReportUsers reportUsers)
        {
            _context.ReportUsers.Remove(reportUsers);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
