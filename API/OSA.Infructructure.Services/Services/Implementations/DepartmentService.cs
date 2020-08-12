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
    public class DepartmentService : IDepartmentService
    {
        IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> Delete(Department entity)
        {
            return _unitOfWork.Departments.Delete(entity);
        }

        public bool DeleteRange(IEnumerable<Department> entities)
        {
            return _unitOfWork.Departments.DeleteRange(entities);
        }

        public Task<Department> Find(Expression<Func<Department, bool>> predicate)
        {
            return _unitOfWork.Departments.Find(predicate);
        }

        public Task<Department> FindById(long Id)
        {
            return _unitOfWork.Departments.FindById(Id);
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return _unitOfWork.Departments.GetAll();
        }

        public Task<IList<DepartmentWiseEmployeeStatisticsVM>> GetDepartmertStat()
        {
            return _unitOfWork.Departments.GetDepartmertStat();
        }

        public Task<bool> Insert(Department entity)
        {
            return _unitOfWork.Departments.Insert(entity);
        }

        public bool InsertRange(IEnumerable<Department> entities)
        {
            return _unitOfWork.Departments.InsertRange(entities);
        }

        public Department SingleOrDefault(Expression<Func<Department, bool>> predicate)
        {
            return _unitOfWork.Departments.SingleOrDefault(predicate);
        }
        public Task<bool> Update(Department entity)
        {
            return _unitOfWork.Departments.Update(entity);
        }
    }
}
