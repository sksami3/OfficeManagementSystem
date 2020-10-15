using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using OSA.Api.Helper;
using OSA.Infructructure.Services.Services.Interfaces;
using OAS.Core.Entity.AuthModels;
using System.Transactions;

namespace OSA.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        #region Initialization
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        private readonly IAttendanceService _attendanceService;
        private readonly HelperClass _helper;

        public EmployeesController(
            IEmployeeService employeeService,
            IUserService userService,
            IAttendanceService attendanceService
            )

        {
            this._employeeService = employeeService;
            _userService = userService;
            _attendanceService = attendanceService;
            _helper = new HelperClass();
        }
        #endregion


        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeService.GetAll();
        }

        [HttpPost("GetEmployeesPost")]
        public async Task<EmployeeViewModel> GetEmployeesPost(object something)
        {
            try
            {
                int start = 0, length = 0;
                string searchValue = "";
                _helper.GetFilterValues(something, ref start, ref length, ref searchValue);

                var result = await _employeeService.GetEmployeesWithDeptName(start, length, searchValue);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            //var employee = await _context.Employees.FindAsync(id);
            var employee = await _employeeService.FindById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(long id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            if (employee.Department != null && employee.Department.Id > 0)
            {
                employee.DepartmentId = employee.Department.Id;
                employee.Department = null;//await _departmentRepository.FindById(employee.Department.Id);                
            }

            try
            {
                bool isEdited = await _employeeService.Update(employee);
            }
            catch (Exception e)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw e;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            User u = new User();
            if (employee.Department != null && employee.Department.Id > 0 && employee.DepartmentId == 0)
            {
                employee.DepartmentId = employee.Department.Id;
                employee.Department = null;//await _departmentRepository.FindById(employee.Department.Id);                
            }
            else if (employee.DepartmentId == 0)
            {
                return NoContent();
            }
            bool isSuccessForEmployee = false;
            bool isSuccessForUser = false;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    isSuccessForEmployee = await _employeeService.Insert(employee);
                    u = _helper.GetUserFromEmployee(employee);
                    u.CreatedBy = User.Identity.Name;
                    u.ModifiedBy = User.Identity.Name;
                    isSuccessForUser = await _userService.Insert(u);
                    scope.Complete();
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    throw e;
                }
                
            }

            if (isSuccessForEmployee && isSuccessForUser)
                return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
            else
                return NoContent();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(long id)
        {
            var employee = await _employeeService.FindById(id);
            if (employee == null)
            {
                return NotFound();
            }

            bool result = await _employeeService.Delete(employee);

            if (result)
                return employee;
            else
                return StatusCode(500);

        }

        private bool EmployeeExists(long id)
        {
            if (_employeeService.FindById(id) == null)
                return true;
            else
                return false;
        }

        [Authorize(Roles = "Employee")]
        [HttpPost("GetTodaysAttendanceInformationByUsername")]
        public async Task<Attendance> GetTodaysAttendanceInformationByUsername(string username)
        {
            Attendance attendance = await _attendanceService.GetTodaysAttendanceInformationByUsername(username);
            if (attendance != null && attendance.Start != null)
                return attendance;
            else
                return null;
        }

        [Authorize(Roles = "Employee")]
        [HttpPost("PresentPlease")]
        public async Task<bool> PresentPlease(Attendance attendance)
        {
            attendance.Employee = await _employeeService.GetEmployeesByUsername(User.Identity.Name.ToString());
            return await _attendanceService.Insert(attendance);
        }

        [Authorize(Roles = "Employee")]
        [HttpPost("GoodByeForToday")]
        public async Task<bool> GoodByeForToday(Attendance attendance)
        {
            attendance.Employee = await _employeeService.GetEmployeesByUsername(User.Identity.Name.ToString());
            Attendance a = await _attendanceService.GetTodaysAttendanceInformationByUsername(User.Identity.Name);
            if (a == null)
                return false;
            else
            {
                a.End = attendance.End;
                return await _attendanceService.Update(a);
            }        
        }
    }
}
