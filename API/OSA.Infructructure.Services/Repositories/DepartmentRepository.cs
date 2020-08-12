using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using OSA.Core.Repository.Repositories;
using OSA.Infructructure.Services.Repositories.Base;
using OSA.Infructure.Context.OASDbContext;

namespace OSA.Infructructure.Services.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private OfficeAttendenceSystemDbContext _context;
        internal DepartmentRepository(OfficeAttendenceSystemDbContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<IList<DepartmentWiseEmployeeStatisticsVM>> GetDepartmertStat()
        {
            var employee = _context.Set<Employee>().ToList();
            var t = from dept in _innerDB.ToList()
                    join emp in employee on dept.Id equals emp.Department.Id
                    select new { dept.Id,dept.Name } into x
                    group x by new { x.Id,x.Name } into g
                    select new DepartmentWiseEmployeeStatisticsVM
                    {
                        Total = g.Count(),
                        DepartmentName = g.Key.Name,
                        //Time = g.Sum(i => i.Zeit)
                    };
            return await Task.FromResult(t.ToList());// await t.ToList();
        }
    }
}
