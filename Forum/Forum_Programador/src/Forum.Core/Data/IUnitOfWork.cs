using System;
using System.Threading.Tasks;

namespace Forum.Core
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
