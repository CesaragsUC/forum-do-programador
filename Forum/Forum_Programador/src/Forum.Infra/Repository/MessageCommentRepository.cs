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
    public class MessageCommentRepository: IMessageCommentRepository
    {
        private readonly ForumContext _context;
        public MessageCommentRepository(ForumContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<MessageComment> GetById(Guid id)
        {
            return  _context.MessageComments.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<MessageComment>> GetByMessageId(Guid messageId)
        {
            return await _context.MessageComments.Where(x => x.PrivateMessageId == messageId).AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<MessageComment>> GetByUserId(Guid userId)
        {
            return await _context.MessageComments.Where(x => x.UserId == userId).AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<MessageComment>> GetAll()
        {
            return await _context.MessageComments.AsNoTracking().ToListAsync();
        }

        public void Add(MessageComment comment)
        {
            _context.MessageComments.Add(comment);
        }

        public void Update(MessageComment comment)
        {
            _context.MessageComments.Update(comment);
        }

        public void Delete(MessageComment comment)
        {
            _context.MessageComments.Remove(comment);
        }
    }
}

