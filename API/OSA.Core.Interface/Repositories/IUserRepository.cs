using OAS.Core.Entity.AuthModels;
using OSA.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Core.Repository.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Authenticate(string username, string password);
        Task<User> GetByUsernameAndPass(string username, string password);
        Task<User> GetByEmail(string email);
        Task<bool> IsAlreadyExists(string username, string email);
        Task<User> CreateUser(User user);
    }
}
