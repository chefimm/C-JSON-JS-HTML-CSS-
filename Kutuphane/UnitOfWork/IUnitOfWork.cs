using Kutuphane.Repositories;

namespace Kutuphane.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositories<T> GetRepositories<T>() where T : class;
  
        int SaveChanges();
    }
}
