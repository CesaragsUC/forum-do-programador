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
    public class UserFriendRepository : IUserFriendRepository
    {

        private readonly ForumContext _context;
        public UserFriendRepository(ForumContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Add(UserFriends userFriends)
        {
            _context.UserFriends.Add(userFriends);
        }

        public void Delete(UserFriends userFriends)
        {
            _context.UserFriends.Remove(userFriends);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<UserFriends>> GetAll()
        {
            return await _context.UserFriends.AsNoTracking().ToListAsync();
        }

        public async Task<UserFriends> GetById(Guid id)
        {
            return _context.UserFriends.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<UserFriends>> GetByUserId(Guid userId)
        {
            return await _context.UserFriends
                .Where(x => x.FriendId == userId)
                .Include(u => u.User)
                .Include(f => f.Friend)
                .AsNoTracking().ToListAsync();
        }

        public void Update(UserFriends userFriends)
        {
            _context.UserFriends.Update(userFriends);
        }


    }
}
