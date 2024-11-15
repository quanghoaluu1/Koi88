using System.Collections.Generic;

namespace Koi88_Service
{
    public interface ICRUDService<T>
    {
        T GetById(int id);
        List<T> GetAll();
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}