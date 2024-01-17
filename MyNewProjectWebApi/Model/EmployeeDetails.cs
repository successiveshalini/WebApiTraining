using System.ComponentModel.DataAnnotations;

namespace MyNewProjectApi.Model
{
    public class EmployeeDetails
    {
        [Key]
        public int EmployeeId { get; set; }
        public string? Name { get; set; }    
        public int Age { get; set; }   
        public string? EmailAddress { get; set; }
        public decimal Amount { get; set; }   
        public string? Address { get; set;}
    }
}
