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
    public class PrivateMessageRepository : IPrivateMessageRepository
    {
        private readonly ForumContext _context;
        public PrivateMessageRepository(ForumContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Add(PrivateMessages message)
        {
            _context.PrivateMessages.Add(message);
        }

        public void Delete(PrivateMessages message)
        {
            _context.PrivateMessages.Remove(message);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<PrivateMessages>> GetAll()
        {
           return await _context.PrivateMessages
                .Include(u=>u.Sender)
                .Include(r=>r.Recipient).AsNoTracking().ToListAsync();
        }

        public async Task<PrivateMessages> GetById(Guid id)
        {
            return  _context.PrivateMessages.Where(x=> x.Id == id).
                                Include(u => u.Sender).
                                 Include(r => r.Recipient).FirstOrDefault();
        }

        public async Task<PrivateMessages> GetByRecipientId(Guid recipientId)
        {
            return _context.PrivateMessages.Where(x => x.SenderId == recipientId)
                                .Include(u => u.Sender)
                                .Include(r => r.Recipient).FirstOrDefault();
        }

        public async Task<PrivateMessages> GetBySenderyId(Guid senderId)
        {
            return _context.PrivateMessages.Where(x => x.SenderId == senderId)
                                .Include(u => u.Sender)
                                .Include(r => r.Recipient).FirstOrDefault();
        }

        public async Task<PrivateMessages> GetBySubject(string subject)
        {
            return  _context.PrivateMessages.Where(x => x.Subject.Contains(subject))
                                         .Include(u => u.Sender)
                                         .Include(r => r.Recipient).FirstOrDefault();
        }

        public void Update(PrivateMessages message)
        {
            _context.PrivateMessages.Update(message);
        }
    }
}
