using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
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
        Task<List<Attendance>> GetCompletedAttendenceByUserName(string username);
    }
}
