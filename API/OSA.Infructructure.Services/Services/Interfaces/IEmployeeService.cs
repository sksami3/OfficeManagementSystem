using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using OSA.Infructructure.Services.Services.Interfaces.Generic;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services.Services.Interfaces
{
    public interface IEmployeeService: IGenericService<Employee>
    {
        Task<EmployeeViewModel> GetEmployeesWithDeptName(int draw, int length, string searchValue);
        Task<Employee> GetEmployeesByUsername(string username);
    }
}
