using Forum.Core;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumContext _context;
        public UserRepository(ForumContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Add(User user)
        {
            _context.Add(user);
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async  Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByIdentityId(Guid identityId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.IdentityId == identityId);
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
