using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Dto;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IEntity<Department> _context;

        public DepartmentsController(IEntity<Department> context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var depts = await _context.GetAll();
            if (depts == null) return NotFound();
            return Ok(depts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            if (id < 1) return BadRequest();
            var dept = await _context.GetById(id);

            if (dept == null) return NotFound();

            return Ok(dept);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentDTO department)
        {
            if (id != department.Id) return BadRequest();
            var dept = await _context.GetById(id);
            if(dept == null) return NotFound();
            
            try
            {
               dept.Name = department.Name;
               await _context.Update(dept);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(dept);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(DepartmentDTO department)
        {
            if (!ModelState.IsValid) return BadRequest();
            Department dept = new Department()
            {
                Name = department.Name,
            };
            try
            {
                await _context.Add(dept);
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtAction("GetDepartment", new { id = dept.Id }, dept);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var dept = await _context.GetById(id);
            if (dept == null) return NotFound();

            try
            {
                await _context.Delete(dept);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(dept);
        }

    }
}
