using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAS.Core.Entity;
using OAS.Core.Entity.ViewModel;
using OSA.Infructructure.Services.Services.Interfaces;

namespace OSA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _departmentService.GetAll(); 
        }
        [HttpGet("GetDepartmertStat")]
        public async Task<List<DepartmentWiseEmployeeStatisticsVM>> GetDepartmertStat()
        {
            IList<DepartmentWiseEmployeeStatisticsVM> result = await _departmentService.GetDepartmertStat();           
            return result.ToList();
        }


        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<Department> GetDepartment(long id)
        {
            Task<Department> department = _departmentService.FindById(id);
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
            departmentFromDb = await _departmentService.FindById(id);
            departmentFromDb.Name = department.Name;
            bool isSuccess = false;
            if (id != department.Id)
            {
                return BadRequest();
            }
            try
            {
                Task<bool> result = _departmentService.Update(departmentFromDb);
                isSuccess = await result;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_departmentService.FindById(id) != null)
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
            _departmentService.Insert(department);
            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(long id)
        {
            var department = await _departmentService.FindById(id);
            if (department == null)
            {
                return NotFound();
            }

            bool result = await _departmentService.Delete(department);

            if (result)
                return department;
            else
                return StatusCode(500);
        }
    }
}
