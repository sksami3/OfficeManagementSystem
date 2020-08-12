using Microsoft.EntityFrameworkCore;
using OSA.Core.Repository;
using OSA.Core.Repository.Repositories;
using OSA.Infructructure.Services.Repositories;
using OSA.Infructure.Context.OASDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OfficeAttendenceSystemDbContext _DbContext;
        DbContextOptionsBuilder<OfficeAttendenceSystemDbContext> _optionsBuilder;
        public UnitOfWork()
        {
            _optionsBuilder = new DbContextOptionsBuilder<OfficeAttendenceSystemDbContext>();
            _DbContext = new OfficeAttendenceSystemDbContext(_optionsBuilder.Options);
            Departments = new DepartmentRepository(_DbContext);
            Employees = new EmployeeRepository(_DbContext);
        }

        public IDepartmentRepository Departments { get; private set; }
        public IEmployeeRepository Employees { get; private set; }


        public Task<int> Complete()
        {
            return _DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _DbContext.DisposeAsync();
        }
    }
}
