using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Model
{
    public class Employee
    {
        [Key]
       public int id { get; set; }
       public string? Nmae { get; set; }
       public string? Email { get; set; }
       public string? department { get; set; }  
    }
}
