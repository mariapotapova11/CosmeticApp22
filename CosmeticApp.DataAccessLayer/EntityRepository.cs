using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmeticApp.Model;

namespace CosmeticApp.DataAccessLayer
{
    /// <summary>
    /// Реализация репозитория через Entity Framework
    /// </summary>
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }

        public T ReadById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            var existing = _context.Set<T>().Find(entity.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
        }
    }
}