﻿using Microsoft.EntityFrameworkCore;
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
        public UnitOfWork(OfficeAttendenceSystemDbContext DbContext)
        {
            _DbContext = DbContext;
            Departments = new DepartmentRepository(_DbContext);
            Employees = new EmployeeRepository(_DbContext);
            Users = new UserRepository(_DbContext);
            Attendances = new AttendanceRepository(_DbContext);
            Attachments = new AttachmentRepository(_DbContext);
        }

        public IDepartmentRepository Departments { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IUserRepository Users { get; private set; }
        public IAttachmentRepository Attachments { get; private set; }
        public IAttendanceRepository Attendances { get; private set; }


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
