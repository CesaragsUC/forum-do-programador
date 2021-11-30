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
    public class UserInformationRepository : IUserInformationRepository
    {
        private readonly ForumContext _context;
        public UserInformationRepository(ForumContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Add(UserInformation information)
        {
            _context.UserInformations.Add(information);
        }

        public void Delete(UserInformation information)
        {
            _context.UserInformations.Remove(information);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<UserInformation>> GetAll()
        {
            return await _context.UserInformations.AsNoTracking().ToListAsync();
        }

        public async Task<UserInformation> GetById(Guid id)
        {
            return _context.UserInformations.Where(x => x.UserId == id).FirstOrDefault();
        }

        public async Task<UserInformation> GetByUserId(Guid userId)
        {
           return  _context.UserInformations.Where(x=>x.UserId == userId).FirstOrDefault();
        }

        public void Update(UserInformation information)
        {
            _context.UserInformations.Update(information);
        }
    }
}
