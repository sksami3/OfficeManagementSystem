using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using OSA.Core.Interface;
using OSA.Api.Helper;

namespace OSA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        #region Initialization
        private readonly IEmployeeRepository _employeeRepository;
        private readonly HelperClass _helper;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
            _helper = new HelperClass();
        }
        #endregion


        // GET: api/Employees
        [HttpGet]
        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetAll();
        }

        [HttpPost("GetEmployeesPost")]
        public async Task<EmployeeViewModel> GetEmployeesPost(object something)
        {
            try
            {
                int start = 0, length = 0;
                string searchValue = "";
                _helper.GetFilterValues(something, ref start, ref length, ref searchValue);

                var result = await _employeeRepository.GetEmployeesWithDeptName(start, length,searchValue);

                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            //var employee = await _context.Employees.FindAsync(id);
            var employee = await _employeeRepository.FindById(id);

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
                bool isEdited = await _employeeRepository.Update(employee);
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
            if (employee.Department != null && employee.Department.Id > 0 && employee.DepartmentId == 0)
            {
                employee.DepartmentId = employee.Department.Id;
                employee.Department = null;//await _departmentRepository.FindById(employee.Department.Id);                
            }
            else if (employee.DepartmentId == 0)
            {
                return NoContent();
            }
            bool isSuccess = false;
            try
            {
                isSuccess = await _employeeRepository.Insert(employee);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (isSuccess)
                return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
            else
                return NoContent();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(long id)
        {
            var employee = await _employeeRepository.FindById(id);
            if (employee == null)
            {
                return NotFound();
            }

            bool result = await _employeeRepository.Delete(employee);

            if (result)
                return employee;
            else
                return StatusCode(500);

        }

        private bool EmployeeExists(long id)
        {
            if (_employeeRepository.FindById(id) == null)
                return true;
            else
                return false;
        }
    }
}
