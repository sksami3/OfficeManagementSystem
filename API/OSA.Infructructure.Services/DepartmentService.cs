using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using OSA.Core.Interface;
using OSA.Infructructure.Services.Base;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OSA.Infructructure.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentRepository
    {
        public async Task<IList<DepartmentWiseEmployeeStatisticsVM>> GetDepartmertStat()
        {
            var employee = _DbContextForOtherUse.Set<Employee>().ToList();
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
            //throw new NotImplementedException();
        }
    }
}
