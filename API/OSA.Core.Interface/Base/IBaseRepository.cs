using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Core.Interface.Base
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> FindById(long Id);
    }
}
