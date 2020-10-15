using OAS.Core.Entity;
using OSA.Core.Repository;
using OSA.Infructructure.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services.Services.Implementations
{
    public class AttendanceService : IAttendanceService
    {
        #region Initialization
        IUnitOfWork _unitOfWork;
        public AttendanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Delete(Attendance entity)
        {
            return _unitOfWork.Attendances.Delete(entity);
        }

        public bool DeleteRange(IEnumerable<Attendance> entities)
        {
            return _unitOfWork.Attendances.DeleteRange(entities);
        }

        public Task<Attendance> Find(Expression<Func<Attendance, bool>> predicate)
        {
            return _unitOfWork.Attendances.Find(predicate);
        }

        public Task<Attendance> FindById(long Id)
        {
            return _unitOfWork.Attendances.FindById(Id);
        }

        public Task<IEnumerable<Attendance>> GetAll()
        {
            return _unitOfWork.Attendances.GetAll();
        }

        public Task<Attendance> GetTodaysAttendanceInformationByUsername(string username)
        {
            return _unitOfWork.Attendances.GetTodaysAttendanceInformationByUsername(username);
        }

        public Task<bool> Insert(Attendance entity)
        {
            return _unitOfWork.Attendances.Insert(entity);
        }

        public bool InsertRange(IEnumerable<Attendance> entities)
        {
            return _unitOfWork.Attendances.InsertRange(entities);
        }

        public Attendance SingleOrDefault(Expression<Func<Attendance, bool>> predicate)
        {
            return _unitOfWork.Attendances.SingleOrDefault(predicate);
        }

        public Task<bool> Update(Attendance entity)
        {
            return _unitOfWork.Attendances.Update(entity);
        }
        #endregion
    }
}
