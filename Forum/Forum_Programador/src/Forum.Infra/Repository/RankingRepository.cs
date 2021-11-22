using Forum.Core;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Infra.Repository
{
    public class RankingRepository : IRankingRepository
    {
        private readonly ForumContext _context;
        public RankingRepository(ForumContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Add(Ranking ranking)
        {
            _context.Add(ranking);
        }

        public void Delete(Ranking ranking)
        {
            _context.Remove(ranking);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async  Task<IEnumerable<Ranking>> GetAll()
        {
            return await _context.Rankings.AsNoTracking().ToListAsync();
        }

        public Task<IEnumerable<Ranking>> GetByCommentId()
        {
            throw new NotImplementedException();
        }

        public async Task<Ranking> GetById(Guid id)
        {
            return await _context.Rankings.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User> GetById(Ranking id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ranking>> GetByTopicId()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ranking>> GetByUserId()
        {
            throw new NotImplementedException();
        }

        public void Update(Ranking ranking)
        {
            _context.Update(ranking);
        }
    }
}
