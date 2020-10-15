using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OAS.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OAS.Core.Entity
{
    public class Attendance : BaseModel
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string ClientsDeviceInfo { get; set; }
        public string WorkDetails { get; set; }
        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
