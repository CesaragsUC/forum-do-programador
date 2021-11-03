using Forum.Core;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Infra.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ForumContext _context;
        public TopicRepository(ForumContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Add(Topic topic)
        {
            _context.Add(topic);
        }

        public void Delete(Topic topic)
        {
            _context.Remove(topic);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async  Task<IEnumerable<Topic>> GetAll()
        {
            return await _context.Topics.AsNoTracking().ToListAsync();
        }

        public async Task<Topic> GetById(Guid id)
        {
            return await _context.Topics.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Topic> GetByUserId(Guid userId)
        {
            return await _context.Topics.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public void Update(Topic topic)
        {
            _context.Update(topic);
        }
    }
}
