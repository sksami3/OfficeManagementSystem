using System;
using System.Collections.Generic;
using System.Text;

namespace OSA.Core.Interface.Base
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T FindById(long Id);
    }
}
