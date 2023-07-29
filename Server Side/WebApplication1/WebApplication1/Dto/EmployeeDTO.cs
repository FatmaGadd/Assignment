using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public char? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Salary { get; set; }
        public int? DeptId { get; set; }
    }
}
