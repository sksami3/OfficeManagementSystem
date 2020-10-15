using Microsoft.AspNetCore.Http;
using OAS.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OAS.Core.Entity
{
    public class Attachment : BaseModel
    {
        //[NotMapped]
        //[Required]
        //[Display(Name = "File")]
        //public IFormFile FormFile { get; set; }
        public string Path { get; set; }
        public string Stage { get; set; }
        [ForeignKey("Attendance")]
        public long? AttendanceId { get; set; }
        public virtual Attendance Attendance { get; set; }
    }
}
