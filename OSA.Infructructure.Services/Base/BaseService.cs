using BOB.DO.Request.ClientFlow;
using Microsoft.EntityFrameworkCore;
using OAS.Core.Entity.Base;
using OSA.Core.Interface.Base;
using OSA.Infructure.Context.OASDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services.Base
{
    public class BaseService<T> : IBaseRepository<T> where T : BaseModel
    {
        private OfficeAttendenceSystemDbContext _DbContext;
        private DbSet<T> _innerDB;
        public BaseService()
        {
            _DbContext = new OfficeAttendenceSystemDbContext();
            _innerDB = _DbContext.Set<T>();
        }
        public bool Delete(T entity)
        {

            throw new NotImplementedException();
        }

        public T FindById(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            var result = _innerDB.ToListAsync();

            return result;
            //throw new NotImplementedException();
        }

        public bool Insert(T entity)
        {
            var x = _DbContext.Set<T>().Add(entity);
            return true;
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        List<T> IBaseRepository<T>.GetAll()
        {
            return GetAll().Result;
        }
    }
}
