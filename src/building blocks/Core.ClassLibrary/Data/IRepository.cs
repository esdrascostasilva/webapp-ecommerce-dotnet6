using System;
using Core.ClassLibrary.DomainObjects;

namespace Core.ClassLibrary.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {

    }
}

