using Kutuphane.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Kutuphane.Repositories
{
    public class Repositories<T> : IRepositories<T> where T : class
    {
        protected readonly Context _context;
        private readonly DbSet<T> _dbSet;//Hata Alıyorum. Daha sonra ne eksik bak.<T> eksikmiş diğer işlemlerde de unutma.
        public Repositories(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public T Add(T entity)//bir hata daha aldım. Hata tip dönüşümü diğer işlemler bitince bak. return kısmında yapmışsın.
        {
            _dbSet.Add(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _dbSet.Remove(entity);
            return entity; 
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if(entity == null) 
            {
                return;
            }
            Delete(entity);
            
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
