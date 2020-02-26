using OAS.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAS.Core.Entity
{
    public class Employee : BaseModel
    {
        public int Name { get; set; }
        public Department Department { get; set; }
    }
}
