using System.Collections.Generic;
using Koi88_BusinessObject;

namespace Koi88_Repository
{
    public interface ICRUDRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}