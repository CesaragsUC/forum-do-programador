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

        public void AddMessageComment(MessageComment messageComment)
        {
            _context.MessageComments.Add(messageComment);
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

        public  void UpdateMessageComment(MessageComment messageComment)
        {
            _context.MessageComments.Update(messageComment);
        }

        public async Task<PrivateMessages> GetById(Guid msgId)
        {
            return   _context.PrivateMessages.Where(x=> x.Id == msgId).
                                Include(u => u.Sender).
                                 Include(r => r.Recipient).FirstOrDefault();
        }

        public async Task<IEnumerable<PrivateMessages>> GetByRecipientId(Guid userId)
        {
            return await _context.PrivateMessages.Where(x => x.RecipientId == userId)
                                .Include(u => u.Sender)
                                .Include(m=>m.MessageComments)
                                .Include(r => r.Recipient)
                                .OrderBy(x=>x.CreationDate).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<PrivateMessages>> GetByRecipientOrSenderId(Guid userId)
        {
            return await _context.PrivateMessages.Where(x => x.RecipientId == userId || x.SenderId == userId)
                .Include(u => u.Sender)
                .Include(m => m.MessageComments)
                .Include(r => r.Recipient)
                .OrderBy(x => x.CreationDate).AsNoTracking().ToListAsync();
        }


        public async Task<IEnumerable<PrivateMessages>> GetBySenderyId(Guid senderId)
        {
            return await _context.PrivateMessages.Where(x => x.SenderId == senderId)
                                .Include(u => u.Sender)
                                .Include(m => m.MessageComments)
                                .Include(r => r.Recipient)
                                .OrderBy(x => x.CreationDate).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<PrivateMessages>> GetBySubject(string subject)
        {
            return await _context.PrivateMessages.Where(x => x.Subject.Contains(subject))
                                         .Include(u => u.Sender)
                                         .Include(m => m.MessageComments)
                                         .Include(r => r.Recipient)
                                         .OrderBy(x => x.CreationDate).AsNoTracking().ToListAsync();
        }

        public void Update(PrivateMessages message)
        {
            _context.PrivateMessages.Update(message);
        }
    }
}
