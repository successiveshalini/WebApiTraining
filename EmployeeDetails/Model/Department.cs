using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string? DepartmentNmae { get; set; }
        public int EmployeeId { get; set; }

    }
}
