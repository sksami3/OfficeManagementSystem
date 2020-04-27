using OAS.Core.Entity;
using OSA.Core.Interface;
using OSA.Infructructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeRepository
    {
        public async Task<IList<Employee>> GetEmployeesWithDeptName()
        {
            var dept = _DbContextForOtherUse.Departments;

            var jt = from e in _DbContextForOtherUse.Employees
                     join d in dept
                    on e.Department.Id equals d.Id
                    where true
                    select new Employee
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Age = e.Age,
                        ContactNumber = e.ContactNumber,
                        CreateDate = e.CreateDate,
                        DateOfBirth = e.DateOfBirth,
                        Department = e.Department,
                        DepartmentId = e.DepartmentId,
                        DepartmentName = d.Name,
                        Email = e.Email,
                        IsDelete = e.IsDelete,
                        JoiningDate = e.JoiningDate,
                        Salary = e.Salary,
                        UpdatedDate = e.UpdatedDate,

                    };


            return await Task.FromResult(jt.ToList());
        }
    }
}
