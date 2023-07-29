using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class EmployeeRepository:IEntity<Employee>,IEmployee
    {
        AssignmentContext dbcontext;
        public EmployeeRepository(AssignmentContext context)
        {
            dbcontext = context;
        }

        public async Task<Employee> Add(Employee entity)
        {
            dbcontext.Add(entity);
            await dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Delete(Employee entity)
        {
            dbcontext.Remove(entity);
            await dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await dbcontext.Employees.ToListAsync();
        }

        public async Task<Employee> GetByEmail(string email)
        {
            return await dbcontext.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Employee> GetById(int id)
        {
            return await dbcontext.Employees.FindAsync(id);
        }

        public async Task<Employee> GetByPhone(string Phone)
        {
            return await dbcontext.Employees.FirstOrDefaultAsync(e => e.Phone == Phone);
        }

        public async Task<Employee> GetBySSN(string ssn)
        {
            return await dbcontext.Employees.FirstOrDefaultAsync(e => e.SSN == ssn);
        }

        public async Task<Employee> Update(Employee entity)
        {
            dbcontext.Entry(entity).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
            return entity;
        }
    }
}
