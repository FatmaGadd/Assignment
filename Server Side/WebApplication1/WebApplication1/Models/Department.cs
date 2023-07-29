using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
