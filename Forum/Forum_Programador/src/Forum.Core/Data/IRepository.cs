using Forum.Core.DomainObjects;
using System;

namespace Forum.Core.Data
{
    public interface IRepository<T>: IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
