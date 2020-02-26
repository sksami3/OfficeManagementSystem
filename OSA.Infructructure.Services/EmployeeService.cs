using OAS.Core.Entity;
using OSA.Core.Interface;
using OSA.Infructructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSA.Infructructure.Services
{
    public class EmployeeService : BaseService<Employee> , IEmployeeRepository
    {
    }
}
