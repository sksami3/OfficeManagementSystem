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
using System.Linq.Expressions;

namespace OSA.Infructructure.Services.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
    {
        protected OfficeAttendenceSystemDbContext _DbContext;
        protected internal DbSet<TEntity> _innerDB;

        internal BaseRepository(OfficeAttendenceSystemDbContext DbContext)
        {
            _DbContext = DbContext;
            _innerDB = _DbContext.Set<TEntity>();
        }
        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                _innerDB.Remove(entity);
                //_DbContext.Entry(entity).State = EntityState.Deleted;
                await _DbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
                throw e;
            }
        }

        public async Task<TEntity> FindById(long Id)
        {
            return await _innerDB.FindAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
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

        public async Task<bool> Insert(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsDelete = false;

           _innerDB.Add(entity);
            try
            {
                await _DbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
            return true;
        }

        public async Task<bool> Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _DbContext.Entry(entity).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();

            return true;
        }

        public Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _innerDB.Where(predicate).FirstAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _innerDB.SingleOrDefault(predicate);
        }

        public bool InsertRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _innerDB.AddRange(entities);
                return true;
            }
            catch(Exception e)
            {
                return false;
                throw e;
            }
            
        }

        public bool DeleteRange(IEnumerable<TEntity> entities)
        {
            try
            {
               _innerDB.RemoveRange(entities);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
            
        }

    }
}
