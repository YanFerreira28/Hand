
using Handcom.Domain.Interfaces.Repository;
using Handcom.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Handcom.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly HandcomContext _context;

        public BaseRepository(HandcomContext context)
        {
            _context = context;
        }
        public void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
