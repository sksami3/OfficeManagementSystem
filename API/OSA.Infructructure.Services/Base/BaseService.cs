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
using System.Linq;
using System.Collections;

namespace OSA.Infructructure.Services.Base
{
    public class BaseService<T> : IBaseRepository<T> where T : BaseModel
    {
        public OfficeAttendenceSystemDbContext _DbContextForOtherUse;
        private OfficeAttendenceSystemDbContext _DbContext;
        internal DbSet<T> _innerDB;
        DbContextOptionsBuilder<OfficeAttendenceSystemDbContext> _optionsBuilder;

        public BaseService()
        {
            _optionsBuilder = new DbContextOptionsBuilder<OfficeAttendenceSystemDbContext>();
            _DbContext = new OfficeAttendenceSystemDbContext(_optionsBuilder.Options);
            _DbContextForOtherUse = new OfficeAttendenceSystemDbContext(_optionsBuilder.Options);
            _innerDB = _DbContext.Set<T>();
        }
        public async Task<bool> Delete(T entity)
        {
            try
            {
                _DbContext.Entry(entity).State = EntityState.Deleted;
                await _DbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
                throw e;
            }
        }

        public async Task<T> FindById(long Id)
        {
            return await _DbContext.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                var result = await _innerDB.Where(x => !x.IsDelete).ToListAsync();
                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Insert(T entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsDelete = false;

            _DbContext.Set<T>().Add(entity);
            await _DbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _DbContext.Entry(entity).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();

            return true;
        }

        //List<T> IBaseRepository<T>.GetAll()
        //{
        //    return GetAll().Result;
        //}
    }
}
