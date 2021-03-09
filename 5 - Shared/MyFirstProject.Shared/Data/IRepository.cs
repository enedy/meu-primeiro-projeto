using System;
using MyFirstProject.Shared.DomainObjects;

namespace MyFirstProject.Shared.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}