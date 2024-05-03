using System.Linq.Expressions;

namespace Kutuphane.Repositories
{
    public interface IRepositories<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);

        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        void Delete(int id);
    }
}
