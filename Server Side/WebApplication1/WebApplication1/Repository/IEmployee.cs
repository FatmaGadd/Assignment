using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IEmployee
    {
        public Task<Employee> GetByEmail(string email);
        public Task<Employee> GetByPhone(string Phone);
        public Task<Employee> GetBySSN(string ssn);
    }
}
