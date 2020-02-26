using OAS.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAS.Core.Entity
{
    public class Department : BaseModel
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
