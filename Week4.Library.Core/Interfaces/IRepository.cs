using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.Library.Core.Interfaces
{
    public interface IRepository<T>
    {
        //CRUD 
        List<T> Fetch();
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}
