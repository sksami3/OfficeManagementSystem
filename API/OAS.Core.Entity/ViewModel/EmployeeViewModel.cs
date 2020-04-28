using System;
using System.Collections.Generic;
using System.Text;

namespace OAS.Core.Entity.ViewModel
{
    public class EmployeeViewModel
    {
        public List<Employee> data { get; set; }
        public int draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
    }
}
