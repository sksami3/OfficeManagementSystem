using OAS.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OAS.Core.Entity
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        [Required]
        public virtual Department Department { get; set; }
    }
}
