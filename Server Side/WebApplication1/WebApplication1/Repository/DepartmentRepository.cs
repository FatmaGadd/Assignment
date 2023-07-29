using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class DepartmentRepository : IEntity<Department>
    {
        AssignmentContext dbcontext;
        public DepartmentRepository(AssignmentContext context)
        {
            dbcontext = context;
        }
        public async Task<Department> Add(Department entity)
        {
            dbcontext.Add(entity);
            await dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<Department> Delete(Department entity)
        {
            dbcontext.Remove(entity);
            await dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Department>> GetAll()
        {
            return await dbcontext.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await dbcontext.Departments.FindAsync(id);
        }

        public async Task<Department> Update(Department entity)
        {
            dbcontext.Entry(entity).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
            return entity;
        }
    }
}
