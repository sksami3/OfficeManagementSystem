using BOB.DO.Request.ClientFlow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        DbContextOptionsBuilder<OfficeAttendenceSystemDbContext> _optionsBuilder;

        public BaseService()
        {
            _optionsBuilder = new DbContextOptionsBuilder<OfficeAttendenceSystemDbContext>();
            _DbContext = new OfficeAttendenceSystemDbContext(_optionsBuilder.Options);
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
            try
            {
                _innerDB = _DbContext.Set<T>();
                var result = _innerDB.ToListAsync();

                return result;
                //throw new NotImplementedException();
            }
            catch(Exception e)
            {

            }
            return null;
        }

        public bool Insert(T entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsDelete = false;

            var x = _DbContext.Set<T>().Add(entity);
            _DbContext.SaveChangesAsync();
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
