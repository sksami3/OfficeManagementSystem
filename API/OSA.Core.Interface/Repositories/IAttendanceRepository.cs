using OAS.Core.Entity;
using OSA.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Core.Repository.Repositories
{
    public interface IAttendanceRepository : IBaseRepository<Attendance>
    {
        Task<Attendance> GetTodaysAttendanceInformationByUsername(string username);
    }
}
