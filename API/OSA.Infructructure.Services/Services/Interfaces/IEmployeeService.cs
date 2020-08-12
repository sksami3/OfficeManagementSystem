using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using OSA.Infructructure.Services.Services.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services.Services.Interfaces
{
    public interface IEmployeeService: IGenericService<Employee>
    {
        Task<EmployeeViewModel> GetEmployeesWithDeptName(int draw, int length, string searchValue);
    }
}
