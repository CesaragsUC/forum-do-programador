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
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumContext _context;
        public CommentRepository(ForumContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Add(Comments comment)
        {
            _context.Add(comment);
        }

        public void Delete(Comments comment)
        {
            _context.Remove(comment);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async  Task<IEnumerable<Comments>> GetAll()
        {
            return await _context.Comments.AsNoTracking().ToListAsync();
        }

        public async Task<Comments> GetById(Guid id)
        {
            return await _context.Comments.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Comments>> GetByTopicId(Guid topicid)
        {
            return await _context.Comments.Where(u => u.TopicId == topicid)
                .Include(x=>x.Topic)
                .Include(u=>u.User)
                .AsNoTracking().ToListAsync();
        }

        public void Update(Comments comment)
        {
            _context.Update(comment);
        }
    }
}
