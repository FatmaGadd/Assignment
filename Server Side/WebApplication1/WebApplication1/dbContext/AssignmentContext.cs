using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.dbContext
{
    public class AssignmentContext:DbContext
    {

        public AssignmentContext(DbContextOptions<AssignmentContext> options):base(options)
        {

        }
        public virtual DbSet<Department> Departments { get; set; }  
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
