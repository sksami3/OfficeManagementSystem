using OAS.Core.Entity;
using OSA.Core.Repository;
using OSA.Infructructure.Services.Services.Interfaces;
using OSA.Infructructure.Services.Services.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Infructructure.Services.Services.Implementations
{
    public class AttachmentService : IAttachmentService
    {
        IUnitOfWork _unitOfWork;
        public AttachmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Delete(Attachment entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRange(IEnumerable<Attachment> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Attachment> Find(Expression<Func<Attachment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Attachment> FindById(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attachment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Attachment entity)
        {
            throw new NotImplementedException();
        }

        public bool InsertRange(IEnumerable<Attachment> entities)
        {
            throw new NotImplementedException();
        }

        public Attachment SingleOrDefault(Expression<Func<Attachment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Attachment entity)
        {
            throw new NotImplementedException();
        }
    }
}
