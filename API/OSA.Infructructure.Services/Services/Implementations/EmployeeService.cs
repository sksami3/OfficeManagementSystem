using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using OSA.Core.Repository;
using OSA.Infructructure.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        #region Initialization
        IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        public Task<bool> Delete(Employee entity)
        {
            return _unitOfWork.Employees.Delete(entity);
        }

        public bool DeleteRange(IEnumerable<Employee> entities)
        {
            return _unitOfWork.Employees.DeleteRange(entities);
        }

        public Task<Employee> Find(Expression<Func<Employee, bool>> predicate)
        {
            return _unitOfWork.Employees.Find(predicate);
        }

        public Task<Employee> FindById(long Id)
        {
            return _unitOfWork.Employees.FindById(Id);
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            return _unitOfWork.Employees.GetAll();
        }

        public Task<EmployeeViewModel> GetEmployeesWithDeptName(int draw, int length, string searchValue)
        {
            return _unitOfWork.Employees.GetEmployeesWithDeptName(draw,length,searchValue);
        }

        public Task<bool> Insert(Employee entity)
        {
            return _unitOfWork.Employees.Insert(entity);
        }

        public bool InsertRange(IEnumerable<Employee> entities)
        {
            return _unitOfWork.Employees.InsertRange(entities);
        }

        public Employee SingleOrDefault(Expression<Func<Employee, bool>> predicate)
        {
            return _unitOfWork.Employees.SingleOrDefault(predicate);
        }

        public Task<bool> Update(Employee entity)
        {
            return _unitOfWork.Employees.Update(entity);
        }
    }
}
