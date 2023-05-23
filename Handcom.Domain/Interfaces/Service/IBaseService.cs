using System.Collections.Generic;

namespace Handcom.Domain.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        public IList<T> GetAll();
        public T GetById(int id);
        public void Insert(T obj);
        public void Delete(T obj);
        public void Update(T obj);
    }
}
