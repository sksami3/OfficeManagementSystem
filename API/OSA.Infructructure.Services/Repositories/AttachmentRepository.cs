using OAS.Core.Entity;
using OSA.Core.Repository.Repositories;
using OSA.Infructructure.Services.Repositories.Base;
using OSA.Infructure.Context.OASDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSA.Infructructure.Services.Repositories
{
    public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
    {
        private OfficeAttendenceSystemDbContext _context;
        internal AttachmentRepository(OfficeAttendenceSystemDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
