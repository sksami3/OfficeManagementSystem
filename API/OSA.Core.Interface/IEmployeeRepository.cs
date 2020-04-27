using OAS.Core.Entity;
using OSA.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Core.Interface
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<IList<Employee>> GetEmployeesWithDeptName();
    }
}
