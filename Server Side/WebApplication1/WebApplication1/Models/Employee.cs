using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    [Index("Email", Name = "email_unique", IsUnique = true)]
    [Index("Phone", Name = "phone_unique", IsUnique = true)]
    [Index("SSN", Name = "ssn_unique", IsUnique = true)]


    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        [StringLength(14)]
        public string SSN { get; set; }
        public char? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Salary { get; set; }
        public int? DeptId { get; set; }

        [ForeignKey("DeptId")]
        [InverseProperty("Employees")]
        public virtual Department Department { get; set; }
    }
}
