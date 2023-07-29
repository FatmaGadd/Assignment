using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.dbContext;
using WebApplication1.Repository;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using WebApplication1.Dto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEntity<Employee> _context;
        IEmployee _eContext;
        public EmployeesController(IEntity<Employee> context, IEmployee eContext)
        {
            _context = context;
            _eContext = eContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var emps = await _context.GetAll();
            if (emps == null) return NotFound();
            return Ok(emps);
        }

        [HttpGet]
        [Route("id/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            if (id < 1) return BadRequest();
            var emp = await _context.GetById(id);

            if (emp == null) return NotFound();

            return Ok(emp);
        }
        [HttpGet]
        [Route("email/{email}")]
        public async Task<ActionResult<Employee>> GetByEmail(string email)
        {
            if (!EmailValidator(email)) return BadRequest("Invalid Email");
            var emp = await _eContext.GetByEmail(email);

            if (emp == null) return NotFound();

            return Ok(emp);
        }
        [HttpGet]
        [Route("phone/{phone}")]
        public async Task<ActionResult<Employee>> GetByPhone(string phone)
        {
            if(!PhoneValidator(phone)) return BadRequest("Invalid Phone");
            var emp = await _eContext.GetByPhone(phone);

            if (emp == null) return NotFound();

            return Ok(emp);
        }
        [HttpGet]
        [Route("ssn/{ssn}")]
        public async Task<ActionResult<Employee>> GetBySSN(string ssn)
        {
            
            if (ssn.Length != 14) return BadRequest("Invalid SSN"); 
            var emp = await _eContext.GetBySSN(ssn);

            if (emp == null) return NotFound();

            return Ok(emp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeDTO employee)
        {
            if (id != employee.Id) return BadRequest();
            var emp = await _context.GetById(id);
            if (emp == null) return NotFound();
            if (!EmailValidator(employee.Email) || !PhoneValidator(employee.Phone)) return BadRequest();

            try
            {
                emp.Name = employee.Name;
                emp.Phone = employee.Phone;
                emp.Email = employee.Email;
                emp.BirthDate = employee.BirthDate;
                emp.Gender = employee.Gender;
                emp.SSN = employee.SSN;
                emp.DeptId = employee.DeptId;
                emp.Salary = employee.Salary;

                await _context.Update(emp);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(emp);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeDTO employee)
        {

            if (!ModelState.IsValid) return BadRequest();
            if (!EmailValidator(employee.Email) || !PhoneValidator(employee.Phone)) return BadRequest();
            Employee emp = new Employee()
            {
                Name = employee.Name,
                Phone = employee.Phone,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                SSN = employee.SSN,
                Email = employee.Email,
                Salary = employee.Salary,
                DeptId = employee.DeptId,
                
            };
            try
            {
                await _context.Add(emp);
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtAction("GetEmployee", new { id = emp.Id }, emp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _context.GetById(id);
            if (emp == null) return NotFound();

            try
            {
                await _context.Delete(emp);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(emp);
        }
        private bool PhoneValidator(string phone)
        {
            Regex regex = new Regex("01[0125][0-9]{8}");
            var match = regex.IsMatch(phone);
            if (match)
                return true;
            return false;
        }
        private bool EmailValidator(string email)
        {
            Regex regex = new Regex("[a-z0-9!#$%&''*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&''*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            var match = regex.IsMatch(email);
            if (match)
                return true;
            return false;
        }
    }
}
