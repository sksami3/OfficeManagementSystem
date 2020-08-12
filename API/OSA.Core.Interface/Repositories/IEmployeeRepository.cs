using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using OSA.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Core.Repository.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<EmployeeViewModel> GetEmployeesWithDeptName(int draw,int length,string searchValue);
    }
}
