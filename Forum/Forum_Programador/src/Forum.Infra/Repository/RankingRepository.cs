using Forum.Core;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<IEnumerable<Ranking>> GetByCommentId(Guid commentId)
        {
            return await _context.Rankings.Where(c=>c.CommentId == commentId).AsNoTracking().ToListAsync();
        }

        public async Task<Ranking> GetById(Guid id)
        {
            return await _context.Rankings.FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task<IEnumerable<Ranking>> GetByTopicId(Guid topicId)
        {
            return await _context.Rankings.Where(c => c.TopicId == topicId).AsNoTracking().ToListAsync();
        }

        public async Task<Ranking> GetByCommentAndUserId(Guid commentId, Guid userId)
        {
            return await _context.Rankings.FirstOrDefaultAsync(u => u.CommentId == commentId && u.UserId == userId);
        }

        public async Task<IEnumerable<Ranking>> GetByUserId(Guid userId)
        {
            return await _context.Rankings.Where(c => c.UserId == userId).AsNoTracking().ToListAsync();
        }

        public void Update(Ranking ranking)
        {
            _context.Update(ranking);
        }
    }
}
