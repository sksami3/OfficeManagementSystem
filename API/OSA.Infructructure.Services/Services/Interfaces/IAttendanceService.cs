using OAS.Core.Entity;
using OSA.Infructructure.Services.Services.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services.Services.Interfaces
{
    public interface IAttendanceService : IGenericService<Attendance>
    {
        Task<Attendance> GetTodaysAttendanceInformationByUsername(string username);
    }
}
