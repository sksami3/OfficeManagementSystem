using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
    //[EnableCors("AllowOrigin")]
    public class DepartmentsController : ControllerBase
    {
        //private readonly OfficeAttendenceSystemDbContext _context;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        // GET: api/Departments
        [HttpGet]
        //[EnableCors("AllowOrigin")]
        public ActionResult<List<Department>> GetDepartments()
        {
            var result = _departmentRepository.GetAll();
            return result;
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<Department> GetDepartment(long id)
        {
            Task<Department> department = _departmentRepository.FindById(id);

            Department dept = await department;

            if (dept == null)
            {
                return null;
            }

            return dept;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(long id, Department department)
        {
            Department departmentFromDb;
            Task<Department> d = _departmentRepository.FindById(id);
            departmentFromDb = await d;
            departmentFromDb.Name = department.Name;
            bool isSuccess = false;
            if (id != department.Id)
            {
                return BadRequest();
            }

            //_context.Entry(department).State = EntityState.Modified;
            try
            {
                Task<bool> result = _departmentRepository.Update(departmentFromDb);
                isSuccess = await result;
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_departmentRepository.FindById(id) != null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            if (isSuccess)
            {
                return Ok(departmentFromDb);
            }
            return NotFound();
        }

        // POST: api/Departments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Department> PostDepartment(Department department)
        {
            _departmentRepository.Insert(department);
            //_context.Departments.Add(department);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(long id)
        {
            var department = await _departmentRepository.FindById(id);
            if (department == null)
            {
                return NotFound();
            }

            bool result = _departmentRepository.Delete(department);

            if (result)
                return department;
            else
                return StatusCode(500);
        }

        //private bool DepartmentExists(long id)
        //{
        //    return _context.Departments.Any(e => e.Id == id);
        //}
    }
}
