using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using OSA.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Core.Interface
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<IList<DepartmentWiseEmployeeStatisticsVM>> GetDepartmertStat();
    }
}
