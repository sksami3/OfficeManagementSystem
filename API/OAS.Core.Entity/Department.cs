using OAS.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAS.Core.Entity
{
    public class Department : BaseModel
    {
        public Department()
        {
            Employees = new List<Employee>();
        }
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
