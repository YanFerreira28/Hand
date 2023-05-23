using Handcom.Domain.Interfaces.Repository;
using Handcom.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace Handcom.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public void Delete(T obj)
        {
            _repository.Delete(obj);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(T obj)
        {
            _repository.Insert(obj);
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
