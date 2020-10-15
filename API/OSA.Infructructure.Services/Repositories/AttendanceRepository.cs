using OAS.Core.Entity;
using OSA.Core.Repository.Repositories;
using OSA.Infructructure.Services.Repositories.Base;
using OSA.Infructure.Context.OASDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OSA.Infructructure.Services.Repositories
{
    public class AttendanceRepository: BaseRepository<Attendance>,IAttendanceRepository
    {
        private OfficeAttendenceSystemDbContext _context;
        internal AttendanceRepository(OfficeAttendenceSystemDbContext context)
            : base(context)
        {
            _context = context;
        }

        public Task<Attendance> GetTodaysAttendanceInformationByUsername(string username)
        {
            return _innerDB.Where(x => !x.IsDelete && x.Employee.User.Username == username && x.Start.Date == DateTime.Today.Date).SingleOrDefaultAsync();
        }
    }
}
