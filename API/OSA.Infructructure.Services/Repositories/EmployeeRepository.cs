using Microsoft.EntityFrameworkCore;
using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using OSA.Core.Repository.Repositories;
using OSA.Infructructure.Services.Repositories.Base;
using OSA.Infructure.Context.OASDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private OfficeAttendenceSystemDbContext _context;
        internal EmployeeRepository(OfficeAttendenceSystemDbContext context)
            : base(context)
        {
            _context = context;
        }

        public  Task<Employee> GetEmployeesByUsername(string username)
        {
            return _innerDB.Where(x => !x.IsDelete && x.User.Username == username).SingleOrDefaultAsync();
        }

        public async Task<EmployeeViewModel> GetEmployeesWithDeptName(int start = 0, int length = 0, string searchValue = "")
        {
            var dept = _context.Departments;

            var eList = from e in _context.Employees
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
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.recordsTotal = eList.Count();
            if (!string.IsNullOrEmpty(searchValue.Trim()))
            {
                evm.data = await Task.FromResult(eList.Where(x => x.Name.Contains(searchValue.Trim()) || x.ContactNumber.ToString().Contains(searchValue.Trim()) || x.Salary.ToString().Contains(searchValue.Trim())).Skip(start).Take(length).ToList());
            }
            else
                evm.data = await Task.FromResult(eList.Skip(start).Take(length).ToList());

            evm.recordsFiltered = evm.data.Count();

            return evm;
        }
    }
}
