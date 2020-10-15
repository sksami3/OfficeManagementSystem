using OAS.Core.Entity.AuthModels;
using OSA.Core.Repository;
using OSA.Infructructure.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Initialization
        IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<User> Authenticate(string username, string password)
        {
            return _unitOfWork.Users.Authenticate(username, password);
        }

        public Task<User> CreateUser(User user)
        {
            return _unitOfWork.Users.CreateUser(user);
        }

        public Task<bool> Delete(User entity)
        {
            return _unitOfWork.Users.Delete(entity);
        }

        public bool DeleteRange(IEnumerable<User> entities)
        {
            return _unitOfWork.Users.DeleteRange(entities);
        }

        public Task<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _unitOfWork.Users.Find(predicate);
        }

        public Task<User> FindById(long Id)
        {
            return _unitOfWork.Users.FindById(Id);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }

        public Task<User> GetByEmail(string email)
        {
            return _unitOfWork.Users.GetByEmail(email);
        }

        public Task<User> GetByUsernameAndPass(string username, string password)
        {
            return _unitOfWork.Users.GetByUsernameAndPass(username,password);
        }

        public Task<bool> Insert(User entity)
        {
            return _unitOfWork.Users.Insert(entity);
        }

        public bool InsertRange(IEnumerable<User> entities)
        {
            return _unitOfWork.Users.InsertRange(entities);
        }

        public Task<bool> IsAlreadyExists(string username, string email)
        {
            return _unitOfWork.Users.IsAlreadyExists(username, email);
        }

        public User SingleOrDefault(Expression<Func<User, bool>> predicate)
        {
            return _unitOfWork.Users.SingleOrDefault(predicate);
        }

        public Task<bool> Update(User entity)
        {
            return _unitOfWork.Users.Update(entity);
        }
        #endregion
    }
}
