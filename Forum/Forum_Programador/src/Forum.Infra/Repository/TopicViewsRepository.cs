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
    public class TopicViewsRepository : ITopicViewsRepository
    {
        private readonly ForumContext _context;
        public TopicViewsRepository(ForumContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Add(TopicViews topicViews)
        {
            _context.TopicViews.Add(topicViews);
        }

        public void Delete(TopicViews topicViews)
        {
            _context.TopicViews.Remove(topicViews);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async  Task<IEnumerable<TopicViews>> GetAll()
        {
            return await _context.TopicViews.AsNoTracking().ToListAsync();
        }

        public async Task<TopicViews> GetById(Guid id)
        {
            return await _context.TopicViews.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<TopicViews>> GetByTopicId(Guid topicId)
        {
            return await _context.TopicViews.Where(u => u.TopicId == topicId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TopicViews>> GetByUserId(Guid userId)
        {
            return await _context.TopicViews.Where(u => u.UserId == userId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TopicViews>> GetByUserAndTopicId(Guid topicId,Guid userId)
        {
            return await _context.TopicViews.Where(u => u.UserId == userId && u.TopicId == topicId)
                .AsNoTracking().ToListAsync();
        }

        public void Update(TopicViews user)
        {
            _context.TopicViews.Update(user);
        }
    }
}
