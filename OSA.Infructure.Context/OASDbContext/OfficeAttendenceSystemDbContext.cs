using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OAS.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                var connectionString = configuration.GetConnectionString("OfficeAttendenceSystemDbContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
