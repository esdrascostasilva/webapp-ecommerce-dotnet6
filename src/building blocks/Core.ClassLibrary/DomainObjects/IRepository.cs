using System;
namespace Core.ClassLibrary.DomainObjects
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {

    }
}

