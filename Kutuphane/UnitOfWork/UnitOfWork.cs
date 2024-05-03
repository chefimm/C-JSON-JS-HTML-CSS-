using Kutuphane.Models;
using Kutuphane.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        /*public UnitOfWork() hata alındı.Para metre gönderme ile alakalı sonra bakıcam.
        {
            _context = new Context();
        }*/
        public UnitOfWork(DbContextOptions<Context> options) 
        {
            _context = new Context(options);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing) 
        {
            if(!this.disposed) 
            {
                if(disposing) 
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepositories<T> GetRepositories<T>() where T : class
        {
            return new Repositories<T>(_context);
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
