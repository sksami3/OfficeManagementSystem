using Microsoft.EntityFrameworkCore;
using OAS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSA.Infructure.Context.OASDbContext
{
    public class OfficeAttendenceSystemDbContext : DbContext
    {
        public OfficeAttendenceSystemDbContext(DbContextOptions<OfficeAttendenceSystemDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
