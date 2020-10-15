using Microsoft.EntityFrameworkCore;
using OAS.Core.Entity.AuthModels;
using OSA.Core.Repository.Repositories;
using OSA.Infructructure.Services.Repositories.Base;
using OSA.Infructure.Context.OASDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services.Repositories
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        private OfficeAttendenceSystemDbContext _context;
        internal UserRepository(OfficeAttendenceSystemDbContext context)
            : base(context)
        {
            _context = context;
        }

        public Task<User> Authenticate(string username, string password)
        {
            return _innerDB.Where(x => x.Username == username && x.Password == password && !x.IsDelete).SingleOrDefaultAsync();
        }

        public async Task<User> CreateUser(User entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsDelete = false;

            _innerDB.Add(entity);
            await _DbContext.SaveChangesAsync();
            return entity;
        }

        public Task<User> GetByEmail(string email)
        {
            return _innerDB.Where(x => x.Email == email && !x.IsDelete).SingleAsync();
        }

        public Task<User> GetByUsernameAndPass(string username, string password)
        {
            return _innerDB.Where(x => x.Username == username && x.Password == password && !x.IsDelete).SingleAsync();
        }

        public Task<bool> IsAlreadyExists(string username, string email)
        {
            return Task.FromResult(_innerDB.Where(x => (x.Username == username || x.Email == email) && !x.IsDelete).Count() > 0);
        }
    }
}
