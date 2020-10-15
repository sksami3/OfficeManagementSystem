using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OAS.Core.Entity;
using OAS.Core.Entity.AuthModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OSA.Infructure.Context.OASDbContext
{
    public class OfficeAttendenceSystemDbContext : DbContext
    {
        public OfficeAttendenceSystemDbContext()
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                var connectionString = configuration.GetConnectionString("OfficeAttendenceSystemDbContext");
                optionsBuilder.UseSqlServer(connectionString);

                optionsBuilder.UseLazyLoadingProxies();
            }
        }
        #region For older .net core versions, it couldn't identify composit keys and tried to add identity on composite keys, that code is written to avoid that 
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Department>().HasKey(a => a.Id);
        //    modelBuilder.Entity<Employee>().HasKey(a => new { a.DepartmentId, a.Id });
        //}
        #endregion
    }
}
