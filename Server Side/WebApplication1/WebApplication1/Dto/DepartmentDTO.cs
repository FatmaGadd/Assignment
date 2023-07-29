using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
