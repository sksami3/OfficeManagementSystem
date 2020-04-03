﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAS.Core.Entity;
using OSA.Core.Interface;
using OSA.Infructure.Context.OASDbContext;

namespace OSA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        #region Delete Later
        private readonly OfficeAttendenceSystemDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(OfficeAttendenceSystemDbContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            this._employeeRepository = employeeRepository;
        }
        #endregion


        // GET: api/Employees
        [HttpGet]
        public ActionResult<IList<Employee>> GetEmployees()
        {
            return _employeeRepository.GetAll();
            //return await _context.Employees.ToListAsync();
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
            //_context.Employees.Add(employee);
            //await _context.SaveChangesAsync();
            bool isSuccess = await _employeeRepository.Insert(employee);
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

            bool result = _employeeRepository.Delete(employee);

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