using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.IRepository
{
    public interface IRepository<T> where T : class 
    {
        public void Add(T entity);
        public T Get(int id);
        public List<T> GetAll();
        public void Update(T entity);
        public void Delete(T entity);
    }
}
