using OSA.Core.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Departments { get; }
        IEmployeeRepository Employees { get; }
        IAttachmentRepository Attachments { get; }
        IAttendanceRepository Attendances { get; }
        IUserRepository Users { get; }
        Task<int> Complete();
    }
}
