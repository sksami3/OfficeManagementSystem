using OSA.Infructructure.Services.Services.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using OAS.Core.Entity.AuthModels;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services.Services.Interfaces
{
    public interface IUserService : IGenericService<User>
    {
        Task<User> Authenticate(string username, string password);
        Task<User> CreateUser(User user);
        Task<User> GetByUsernameAndPass(string username, string password);
        Task<User> GetByEmail(string email);
        Task<bool> IsAlreadyExists(string username, string email);
    }
}
