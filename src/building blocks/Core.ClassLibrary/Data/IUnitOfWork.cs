using System;
namespace Core.ClassLibrary.Data
{
	public interface IUnitOfWork
	{
		Task<bool> Commit();
	}
}

